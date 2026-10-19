using Bai5.Helpers;
using Bai5.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bai5;

/// <summary>Tab "Tour": thêm / sửa / xóa tour và tìm theo tên hoặc điểm đến.</summary>
public partial class UcTour : UserControl
{
    private List<TourItem> _dsTour = new();
    private int? _maDangChon;
    private bool _dangNap;

    public UcTour()
    {
        InitializeComponent();
        TaoCotLuoi();
        LamMoiO();
    }

    private void TaoCotLuoi()
    {
        dgvTour.Columns.Add("MaTour", "Mã");
        dgvTour.Columns.Add("TenTour", "Tên tour");
        dgvTour.Columns.Add("DiemDen", "Điểm đến");
        dgvTour.Columns.Add("NgoaiTe", "Ngoại tệ");
        dgvTour.Columns.Add("GiaNgoaiTe", "Giá/người");
        dgvTour.Columns.Add("NgayKhoiHanh", "Khởi hành");
        dgvTour.Columns.Add("SoChoToiDa", "Số chỗ");
        dgvTour.Columns.Add("DaDat", "Đã đặt");
        dgvTour.Columns.Add("ConLai", "Còn lại");

        dgvTour.Columns["MaTour"]!.FillWeight = 40;
        dgvTour.Columns["TenTour"]!.FillWeight = 220;
        dgvTour.Columns["NgoaiTe"]!.FillWeight = 55;
        foreach (string ten in new[] { "GiaNgoaiTe", "SoChoToiDa", "DaDat", "ConLai" })
            dgvTour.Columns[ten]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        foreach (string ten in new[] { "SoChoToiDa", "DaDat", "ConLai" })
            dgvTour.Columns[ten]!.FillWeight = 55;
    }

    /// <summary>Nạp danh sách tour (có lọc theo ô tìm kiếm).</summary>
    public async Task NapDuLieuAsync()
    {
        if (_dangNap) return;
        _dangNap = true;
        try
        {
            string tuKhoa = txtTim.Text.Trim();
            using var db = DbContextHelper.GetContext();

            IQueryable<Tour> q = db.Tours.AsNoTracking();
            if (tuKhoa.Length > 0)
                q = q.Where(t => t.TenTour.Contains(tuKhoa) || t.DiemDen.Contains(tuKhoa));

            _dsTour = await q
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

            dgvTour.Rows.Clear();
            foreach (var t in _dsTour)
            {
                dgvTour.Rows.Add(t.MaTour, t.TenTour, t.DiemDen, t.NgoaiTe,
                    t.GiaNgoaiTe.ToString("#,##0.##", DinhDang.Vi),
                    DinhDang.Ngay(t.NgayKhoiHanh), t.SoChoToiDa, t.DaDat, t.ConLai);
            }
            dgvTour.ClearSelection();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "tải danh sách tour");
        }
        finally
        {
            _dangNap = false;
        }
    }

    private void DgvTour_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dangNap || dgvTour.CurrentRow == null || !dgvTour.CurrentRow.Selected) return;

        int ma = Convert.ToInt32(dgvTour.CurrentRow.Cells["MaTour"].Value);
        var t = _dsTour.FirstOrDefault(x => x.MaTour == ma);
        if (t == null) return;

        _maDangChon = t.MaTour;
        txtMaTour.Text = t.MaTour.ToString();
        txtTenTour.Text = t.TenTour;
        txtDiemDen.Text = t.DiemDen;
        cboNgoaiTe.SelectedItem = t.NgoaiTe.Trim();
        nudGia.Value = Math.Clamp(t.GiaNgoaiTe, nudGia.Minimum, nudGia.Maximum);
        dtpKhoiHanh.Value = t.NgayKhoiHanh.ToDateTime(TimeOnly.MinValue);
        nudSoCho.Value = Math.Clamp(t.SoChoToiDa, (int)nudSoCho.Minimum, (int)nudSoCho.Maximum);
    }

    private bool KiemTraHopLe(bool laThemMoi)
    {
        if (string.IsNullOrWhiteSpace(txtTenTour.Text))
        {
            UiHelper.CanhBao("Tên tour không được để trống.");
            txtTenTour.Focus();
            return false;
        }
        if (string.IsNullOrWhiteSpace(txtDiemDen.Text))
        {
            UiHelper.CanhBao("Điểm đến không được để trống.");
            txtDiemDen.Focus();
            return false;
        }
        if (cboNgoaiTe.SelectedItem == null)
        {
            UiHelper.CanhBao("Hãy chọn ngoại tệ.");
            return false;
        }
        if (nudGia.Value <= 0)
        {
            UiHelper.CanhBao("Giá ngoại tệ phải lớn hơn 0.");
            nudGia.Focus();
            return false;
        }
        if (laThemMoi && dtpKhoiHanh.Value.Date < DateTime.Today)
        {
            UiHelper.CanhBao("Ngày khởi hành không được nhỏ hơn hôm nay.");
            return false;
        }
        return true;
    }

    private void GanDuLieu(Tour t)
    {
        t.TenTour = txtTenTour.Text.Trim();
        t.DiemDen = txtDiemDen.Text.Trim();
        t.NgoaiTe = cboNgoaiTe.SelectedItem!.ToString()!;
        t.GiaNgoaiTe = nudGia.Value;
        t.NgayKhoiHanh = DateOnly.FromDateTime(dtpKhoiHanh.Value.Date);
        t.SoChoToiDa = (int)nudSoCho.Value;
    }

    private async void BtnThem_Click(object? sender, EventArgs e)
    {
        if (!KiemTraHopLe(laThemMoi: true)) return;
        try
        {
            using var db = DbContextHelper.GetContext();
            var tour = new Tour();
            GanDuLieu(tour);
            db.Tours.Add(tour);
            await db.SaveChangesAsync();

            Log.Information("Thêm tour {MaTour} - {TenTour}", tour.MaTour, tour.TenTour);
            UiHelper.ThongBao("Đã thêm tour mới.");
            LamMoiO();
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "thêm tour");
        }
    }

    private async void BtnSua_Click(object? sender, EventArgs e)
    {
        if (_maDangChon == null)
        {
            UiHelper.CanhBao("Hãy chọn tour cần sửa trong danh sách.");
            return;
        }
        if (!KiemTraHopLe(laThemMoi: false)) return;

        try
        {
            using var db = DbContextHelper.GetContext();
            var tour = await db.Tours.FindAsync(_maDangChon.Value);
            if (tour == null)
            {
                UiHelper.CanhBao("Tour không còn tồn tại.");
                await NapDuLieuAsync();
                return;
            }

            // Không cho giảm số chỗ xuống thấp hơn số người đã đặt
            int daDat = await db.DatTours.Where(d => d.MaTour == tour.MaTour).SumAsync(d => d.SoNguoi);
            if (nudSoCho.Value < daDat)
            {
                UiHelper.CanhBao($"Tour này đã có {daDat} người đặt, số chỗ tối đa không được nhỏ hơn {daDat}.");
                return;
            }

            GanDuLieu(tour);
            await db.SaveChangesAsync();

            Log.Information("Sửa tour {MaTour} - {TenTour}", tour.MaTour, tour.TenTour);
            UiHelper.ThongBao("Đã cập nhật tour.");
            LamMoiO();
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "sửa tour");
        }
    }

    private async void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_maDangChon == null)
        {
            UiHelper.CanhBao("Hãy chọn tour cần xóa trong danh sách.");
            return;
        }

        try
        {
            using var db = DbContextHelper.GetContext();
            var tour = await db.Tours.FindAsync(_maDangChon.Value);
            if (tour == null)
            {
                await NapDuLieuAsync();
                return;
            }

            if (await db.DatTours.AnyAsync(d => d.MaTour == tour.MaTour))
            {
                UiHelper.CanhBao("Tour này đã có khách đặt nên không thể xóa.\nHãy hủy các đơn đặt tour trước.");
                return;
            }

            if (!UiHelper.XacNhan($"Bạn có chắc muốn xóa tour \"{tour.TenTour}\"?")) return;

            db.Tours.Remove(tour);
            await db.SaveChangesAsync();

            Log.Information("Xóa tour {MaTour} - {TenTour}", tour.MaTour, tour.TenTour);
            LamMoiO();
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "xóa tour");
        }
    }

    private async void BtnLamMoi_Click(object? sender, EventArgs e)
    {
        LamMoiO();
        await NapDuLieuAsync();
    }

    private async void BtnTim_Click(object? sender, EventArgs e)
    {
        await NapDuLieuAsync();
    }

    private async void BtnHienTatCa_Click(object? sender, EventArgs e)
    {
        txtTim.Clear();
        await NapDuLieuAsync();
    }

    private async void TxtTim_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        await NapDuLieuAsync();
    }

    private void LamMoiO()
    {
        _maDangChon = null;
        txtMaTour.Clear();
        txtTenTour.Clear();
        txtDiemDen.Clear();
        cboNgoaiTe.SelectedIndex = 0;
        nudGia.Value = 0;
        dtpKhoiHanh.Value = DateTime.Today.AddDays(30);
        nudSoCho.Value = 20;
        dgvTour.ClearSelection();
        txtTenTour.Focus();
    }
}
