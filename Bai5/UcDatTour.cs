using Bai5.Helpers;
using Bai5.Models;
using Bai5.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bai5;

/// <summary>
/// Tab "Đặt tour": chọn khách + tour + số người, lấy tỷ giá từ API để quy đổi ra VND và lưu đơn;
/// bên dưới là danh sách đặt tour (JOIN 3 bảng), tìm kiếm và tổng doanh thu.
/// </summary>
public partial class UcDatTour : UserControl
{
    private List<DatTourDong> _dsDat = new();
    private KetQuaTyGia? _tyGia;      // tỷ giá của tour đang chọn
    private int _phienTyGia;          // tránh kết quả cũ ghi đè khi người dùng đổi tour liên tục
    private bool _dangNapCombo;
    private bool _dangNapLuoi;

    public UcDatTour()
    {
        InitializeComponent();
        TaoCotLuoi();
        dtpThang.Value = DateTime.Today;
    }

    private void TaoCotLuoi()
    {
        dgvDatTour.Columns.Add("MaDat", "Mã đặt");
        dgvDatTour.Columns.Add("HoTen", "Họ tên khách");
        dgvDatTour.Columns.Add("TenTour", "Tên tour");
        dgvDatTour.Columns.Add("NgayKhoiHanh", "Khởi hành");
        dgvDatTour.Columns.Add("SoNguoi", "Số người");
        dgvDatTour.Columns.Add("TyGia", "Tỷ giá");
        dgvDatTour.Columns.Add("TongTienVND", "Tổng tiền VND");
        dgvDatTour.Columns.Add("NgayDat", "Ngày đặt");

        dgvDatTour.Columns["MaDat"]!.FillWeight = 50;
        dgvDatTour.Columns["TenTour"]!.FillWeight = 210;
        dgvDatTour.Columns["SoNguoi"]!.FillWeight = 60;
        foreach (string ten in new[] { "SoNguoi", "TyGia", "TongTienVND" })
            dgvDatTour.Columns[ten]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    /// <summary>Nạp lại ComboBox khách/tour và danh sách đặt tour.</summary>
    public async Task NapDuLieuAsync()
    {
        await NapComboAsync();
        await NapDanhSachAsync();
    }

    // ===================== PHẦN ĐẶT TOUR =====================

    private async Task NapComboAsync()
    {
        if (_dangNapCombo) return;

        // Giữ lại lựa chọn hiện tại để không bị nhảy về dòng đầu
        int? khachCu = (cboKhachHang.SelectedItem as KhachHangItem)?.MaKH;
        int? tourCu = (cboTour.SelectedItem as TourItem)?.MaTour;

        _dangNapCombo = true;
        try
        {
            using var db = DbContextHelper.GetContext();

            var dsKhach = await db.KhachHangs.AsNoTracking()
                .OrderBy(k => k.HoTen)
                .Select(k => new KhachHangItem { MaKH = k.MaKH, HoTen = k.HoTen, SoDienThoai = k.SoDienThoai })
                .ToListAsync();

            // Chỉ cho đặt các tour chưa khởi hành
            var homNay = DateOnly.FromDateTime(DateTime.Today);
            var dsTour = await db.Tours.AsNoTracking()
                .Where(t => t.NgayKhoiHanh >= homNay)
                .OrderBy(t => t.NgayKhoiHanh)
                .Select(t => new TourItem
                {
                    MaTour = t.MaTour,
                    TenTour = t.TenTour,
                    DiemDen = t.DiemDen,
                    NgoaiTe = t.NgoaiTe,
                    GiaNgoaiTe = t.GiaNgoaiTe,
                    NgayKhoiHanh = t.NgayKhoiHanh,
                    SoChoToiDa = t.SoChoToiDa,
                    DaDat = t.DatTours.Sum(d => d.SoNguoi)
                })
                .ToListAsync();

            cboKhachHang.DataSource = null;
            cboKhachHang.DisplayMember = nameof(KhachHangItem.HienThi);
            cboKhachHang.ValueMember = nameof(KhachHangItem.MaKH);
            cboKhachHang.DataSource = dsKhach;
            if (khachCu.HasValue && dsKhach.Any(k => k.MaKH == khachCu.Value))
                cboKhachHang.SelectedValue = khachCu.Value;

            cboTour.DataSource = null;
            cboTour.DisplayMember = nameof(TourItem.HienThi);
            cboTour.ValueMember = nameof(TourItem.MaTour);
            cboTour.DataSource = dsTour;
            if (tourCu.HasValue && dsTour.Any(t => t.MaTour == tourCu.Value))
                cboTour.SelectedValue = tourCu.Value;
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "tải danh sách khách hàng và tour");
        }
        finally
        {
            _dangNapCombo = false;
        }

        await CapNhatTourDangChonAsync(boQuaCache: false);
    }

    private async void CboTour_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNapCombo) return;
        await CapNhatTourDangChonAsync(boQuaCache: false);
    }

    private void CboKhachHang_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_dangNapCombo) return;
        TinhTien();
    }

    private void NudSoNguoi_ValueChanged(object? sender, EventArgs e)
    {
        TinhTien();
    }

    private async void BtnTaiLaiTyGia_Click(object? sender, EventArgs e)
    {
        TyGiaService.XoaBoNhoDem();
        await CapNhatTourDangChonAsync(boQuaCache: true);
    }

    /// <summary>Hiển thị giá, số chỗ còn lại và gọi API lấy tỷ giá cho tour đang chọn.</summary>
    private async Task CapNhatTourDangChonAsync(bool boQuaCache)
    {
        int phien = ++_phienTyGia;
        _tyGia = null;

        if (cboTour.SelectedItem is not TourItem tour)
        {
            lblGiaNgoaiTe.Text = "Giá/người (ngoại tệ): —";
            lblConLai.Text = "Còn lại: —";
            lblConLai.ForeColor = SystemColors.ControlText;
            lblTyGia.Text = "Tỷ giá: —";
            lblNguonTyGia.Text = "";
            DangTaiTyGia(false);
            TinhTien();
            return;
        }

        lblGiaNgoaiTe.Text = $"Giá/người (ngoại tệ): {DinhDang.NgoaiTe(tour.GiaNgoaiTe, tour.NgoaiTe)}";
        if (tour.ConLai > 0)
        {
            lblConLai.Text = $"Còn lại: {tour.ConLai}/{tour.SoChoToiDa} chỗ";
            lblConLai.ForeColor = Color.DarkGreen;
        }
        else
        {
            lblConLai.Text = "Tour đã hết chỗ";
            lblConLai.ForeColor = Color.Firebrick;
        }

        lblTyGia.Text = $"Tỷ giá {tour.NgoaiTe} → VND: đang tải…";
        lblNguonTyGia.Text = "";
        DangTaiTyGia(true);
        TinhTien();

        try
        {
            var ketQua = await TyGiaService.LayTyGiaChiTietAsync(tour.NgoaiTe, boQuaCache);
            if (phien != _phienTyGia) return;   // người dùng đã chọn tour khác trong lúc chờ

            _tyGia = ketQua;
            lblTyGia.Text = $"Tỷ giá: 1 {tour.NgoaiTe} = {DinhDang.TyGia(ketQua.TyGia)} đ";
            lblNguonTyGia.Text =
                $"{(ketQua.TuBoNhoDem ? "Lấy từ bộ nhớ đệm" : "Vừa cập nhật")} lúc {ketQua.ThoiDiemLay:HH:mm:ss}" +
                $" · dữ liệu ngày {ketQua.NgayDuLieu}" +
                $" · {(ketQua.LaNguonDuPhong ? "nguồn dự phòng" : "nguồn chính")}";
        }
        catch (TyGiaException ex)
        {
            if (phien != _phienTyGia) return;
            lblTyGia.Text = "Tỷ giá: không lấy được";
            lblNguonTyGia.Text = "Bấm \"Tải lại tỷ giá\" để thử lại.";
            UiHelper.CanhBao(ex.Message);
        }
        finally
        {
            if (phien == _phienTyGia)
            {
                DangTaiTyGia(false);
                TinhTien();
            }
        }
    }

    private void DangTaiTyGia(bool dangTai)
    {
        prgTyGia.Visible = dangTai;
        btnTaiLaiTyGia.Enabled = !dangTai;
        if (dangTai) btnDatTour.Enabled = false;
    }

    /// <summary>Tính giá/người và tổng tiền VND = giá ngoại tệ × số người × tỷ giá.</summary>
    private void TinhTien()
    {
        var tour = cboTour.SelectedItem as TourItem;
        if (tour == null || _tyGia == null)
        {
            lblGiaVnd.Text = "Giá/người (VND): —";
            lblTongTien.Text = "Tổng tiền: —";
            btnDatTour.Enabled = false;
            return;
        }

        decimal giaVnd = Math.Round(tour.GiaNgoaiTe * _tyGia.TyGia, 0);
        decimal tongTien = Math.Round(tour.GiaNgoaiTe * nudSoNguoi.Value * _tyGia.TyGia, 0);

        lblGiaVnd.Text = $"Giá/người (VND): {DinhDang.Tien(giaVnd)}";
        lblTongTien.Text = $"Tổng tiền: {DinhDang.Tien(tongTien)}";
        btnDatTour.Enabled = !prgTyGia.Visible && tour.ConLai > 0 && cboKhachHang.SelectedItem != null;
    }

    private async void BtnDatTour_Click(object? sender, EventArgs e)
    {
        if (cboKhachHang.SelectedItem is not KhachHangItem khach)
        {
            UiHelper.CanhBao("Hãy chọn khách hàng.");
            return;
        }
        if (cboTour.SelectedItem is not TourItem tour)
        {
            UiHelper.CanhBao("Hãy chọn tour.");
            return;
        }
        var tyGia = _tyGia;
        if (tyGia == null)
        {
            UiHelper.CanhBao("Chưa có tỷ giá cho tour này. Bấm \"Tải lại tỷ giá\" rồi thử lại.");
            return;
        }

        int soNguoi = (int)nudSoNguoi.Value;
        btnDatTour.Enabled = false;
        try
        {
            using var db = DbContextHelper.GetContext();

            // Kiểm tra lại số chỗ còn lại ngay trong CSDL (dữ liệu trên form có thể đã cũ)
            var t = await db.Tours.AsNoTracking()
                .Where(x => x.MaTour == tour.MaTour)
                .Select(x => new { x.SoChoToiDa, x.GiaNgoaiTe, x.NgoaiTe, DaDat = x.DatTours.Sum(d => d.SoNguoi) })
                .FirstOrDefaultAsync();

            if (t == null)
            {
                UiHelper.CanhBao("Tour này không còn tồn tại.");
                await NapDuLieuAsync();
                return;
            }
            if (!string.Equals(t.NgoaiTe.Trim(), tyGia.NgoaiTe, StringComparison.OrdinalIgnoreCase))
            {
                UiHelper.CanhBao("Ngoại tệ của tour vừa được thay đổi. Dữ liệu sẽ được tải lại, vui lòng kiểm tra rồi đặt lại.");
                await NapDuLieuAsync();
                return;
            }

            int conLai = t.SoChoToiDa - t.DaDat;
            if (soNguoi > conLai)
            {
                Log.Warning("Chặn đặt vượt chỗ: tour {MaTour} còn {ConLai} chỗ, yêu cầu {SoNguoi} người", tour.MaTour, conLai, soNguoi);
                UiHelper.CanhBao(conLai <= 0
                    ? $"Tour \"{tour.TenTour}\" đã hết chỗ."
                    : $"Không đủ chỗ! Tour \"{tour.TenTour}\" chỉ còn {conLai} chỗ, bạn đang đặt {soNguoi} người.");
                await NapComboAsync();
                return;
            }

            decimal tongTien = Math.Round(t.GiaNgoaiTe * soNguoi * tyGia.TyGia, 0);
            var don = new DatTour
            {
                MaKH = khach.MaKH,
                MaTour = tour.MaTour,
                SoNguoi = soNguoi,
                NgayDat = DateTime.Now,
                TyGia = tyGia.TyGia,          // lưu tỷ giá tại thời điểm đặt
                TongTienVND = tongTien
            };
            db.DatTours.Add(don);
            await db.SaveChangesAsync();

            Log.Information("Đặt tour {MaDat}: khách {MaKH}, tour {MaTour}, {SoNguoi} người, tỷ giá {TyGia}, tổng {TongTien} VND",
                don.MaDat, don.MaKH, don.MaTour, don.SoNguoi, don.TyGia, don.TongTienVND);
            UiHelper.ThongBao($"Đặt tour thành công!\n\nMã đặt: {don.MaDat}\nKhách hàng: {khach.HoTen}\nTour: {tour.TenTour}\n" +
                              $"Số người: {soNguoi}\nTỷ giá: 1 {tyGia.NgoaiTe} = {DinhDang.TyGia(tyGia.TyGia)} đ\nTổng tiền: {DinhDang.Tien(tongTien)}");

            nudSoNguoi.Value = 1;
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "đặt tour");
        }
        finally
        {
            TinhTien();
        }
    }

    // ===================== DANH SÁCH ĐẶT TOUR =====================

    /// <summary>JOIN DatTour – KhachHang – Tour, lọc theo tên khách / tên tour / tháng khởi hành.</summary>
    private async Task NapDanhSachAsync()
    {
        if (_dangNapLuoi) return;
        _dangNapLuoi = true;
        try
        {
            string tuKhoa = txtTim.Text.Trim();
            using var db = DbContextHelper.GetContext();

            var q = from d in db.DatTours.AsNoTracking()
                    join k in db.KhachHangs on d.MaKH equals k.MaKH
                    join t in db.Tours on d.MaTour equals t.MaTour
                    select new DatTourDong
                    {
                        MaDat = d.MaDat,
                        HoTen = k.HoTen,
                        TenTour = t.TenTour,
                        NgoaiTe = t.NgoaiTe,
                        NgayKhoiHanh = t.NgayKhoiHanh,
                        SoNguoi = d.SoNguoi,
                        TyGia = d.TyGia,
                        TongTienVND = d.TongTienVND,
                        NgayDat = d.NgayDat
                    };

            if (tuKhoa.Length > 0)
                q = q.Where(x => x.HoTen.Contains(tuKhoa) || x.TenTour.Contains(tuKhoa));

            if (chkLocThang.Checked)
            {
                var dauThang = new DateOnly(dtpThang.Value.Year, dtpThang.Value.Month, 1);
                var dauThangSau = dauThang.AddMonths(1);
                q = q.Where(x => x.NgayKhoiHanh >= dauThang && x.NgayKhoiHanh < dauThangSau);
            }

            _dsDat = await q.OrderByDescending(x => x.NgayDat).ToListAsync();

            dgvDatTour.Rows.Clear();
            foreach (var d in _dsDat)
            {
                dgvDatTour.Rows.Add(d.MaDat, d.HoTen, d.TenTour, DinhDang.Ngay(d.NgayKhoiHanh), d.SoNguoi,
                    $"{DinhDang.TyGia(d.TyGia)} ({d.NgoaiTe.Trim()})", DinhDang.Tien(d.TongTienVND), DinhDang.NgayGio(d.NgayDat));
            }
            dgvDatTour.ClearSelection();

            // Tổng doanh thu của các dòng ĐANG hiển thị
            decimal tong = _dsDat.Sum(d => d.TongTienVND);
            lblTongDoanhThu.Text = $"Tổng doanh thu: {DinhDang.Tien(tong)}  ({_dsDat.Count} đơn, {_dsDat.Sum(d => d.SoNguoi)} khách)";
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "tải danh sách đặt tour");
        }
        finally
        {
            _dangNapLuoi = false;
        }
    }

    private async void BtnTim_Click(object? sender, EventArgs e)
    {
        await NapDanhSachAsync();
    }

    private async void TxtTim_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        await NapDanhSachAsync();
    }

    private async void ChkLocThang_CheckedChanged(object? sender, EventArgs e)
    {
        dtpThang.Enabled = chkLocThang.Checked;
        await NapDanhSachAsync();
    }

    private async void DtpThang_ValueChanged(object? sender, EventArgs e)
    {
        if (chkLocThang.Checked)
            await NapDanhSachAsync();
    }

    private async void BtnBoLoc_Click(object? sender, EventArgs e)
    {
        txtTim.Clear();
        chkLocThang.Checked = false;   // sự kiện CheckedChanged sẽ tự nạp lại nếu trạng thái thay đổi
        await NapDanhSachAsync();
    }

    private async void BtnHuyDat_Click(object? sender, EventArgs e)
    {
        if (dgvDatTour.CurrentRow == null || !dgvDatTour.CurrentRow.Selected)
        {
            UiHelper.CanhBao("Hãy chọn đơn đặt tour cần hủy trong danh sách.");
            return;
        }

        int maDat = Convert.ToInt32(dgvDatTour.CurrentRow.Cells["MaDat"].Value);
        var dong = _dsDat.FirstOrDefault(d => d.MaDat == maDat);
        if (dong == null) return;

        if (!UiHelper.XacNhan($"Hủy đơn #{dong.MaDat} của \"{dong.HoTen}\" (tour \"{dong.TenTour}\", {dong.SoNguoi} người)?"))
            return;

        try
        {
            using var db = DbContextHelper.GetContext();
            var don = await db.DatTours.FindAsync(maDat);
            if (don != null)
            {
                db.DatTours.Remove(don);
                await db.SaveChangesAsync();
                Log.Information("Hủy đơn đặt tour {MaDat} (tour {MaTour}, {SoNguoi} người)", don.MaDat, don.MaTour, don.SoNguoi);
            }
            await NapDuLieuAsync();   // cập nhật lại số chỗ còn lại + danh sách
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "hủy đơn đặt tour");
        }
    }
}
