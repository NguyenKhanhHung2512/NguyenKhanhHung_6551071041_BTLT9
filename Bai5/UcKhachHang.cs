using System.Net.Mail;
using System.Text.RegularExpressions;
using Bai5.Helpers;
using Bai5.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Bai5;

/// <summary>Tab "Khách hàng": thêm / sửa / xóa khách hàng và tìm theo tên hoặc số điện thoại.</summary>
public partial class UcKhachHang : UserControl
{
    private List<KhachHangItem> _dsKhach = new();
    private int? _maDangChon;
    private bool _dangNap;

    public UcKhachHang()
    {
        InitializeComponent();
        TaoCotLuoi();
    }

    private void TaoCotLuoi()
    {
        dgvKhachHang.Columns.Add("MaKH", "Mã KH");
        dgvKhachHang.Columns.Add("HoTen", "Họ tên");
        dgvKhachHang.Columns.Add("SoDienThoai", "Số điện thoại");
        dgvKhachHang.Columns.Add("Email", "Email");
        dgvKhachHang.Columns.Add("SoDon", "Số đơn đặt");

        dgvKhachHang.Columns["MaKH"]!.FillWeight = 40;
        dgvKhachHang.Columns["HoTen"]!.FillWeight = 160;
        dgvKhachHang.Columns["Email"]!.FillWeight = 160;
        dgvKhachHang.Columns["SoDon"]!.FillWeight = 60;
        dgvKhachHang.Columns["SoDon"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    /// <summary>Nạp danh sách khách hàng (có lọc theo ô tìm kiếm).</summary>
    public async Task NapDuLieuAsync()
    {
        if (_dangNap) return;
        _dangNap = true;
        try
        {
            string tuKhoa = txtTim.Text.Trim();
            using var db = DbContextHelper.GetContext();

            IQueryable<KhachHang> q = db.KhachHangs.AsNoTracking();
            if (tuKhoa.Length > 0)
                q = q.Where(k => k.HoTen.Contains(tuKhoa) || k.SoDienThoai.Contains(tuKhoa));

            _dsKhach = await q
                .OrderBy(k => k.HoTen)
                .Select(k => new KhachHangItem
                {
                    MaKH = k.MaKH,
                    HoTen = k.HoTen,
                    SoDienThoai = k.SoDienThoai,
                    Email = k.Email,
                    SoDon = k.DatTours.Count
                })
                .ToListAsync();

            dgvKhachHang.Rows.Clear();
            foreach (var k in _dsKhach)
                dgvKhachHang.Rows.Add(k.MaKH, k.HoTen, k.SoDienThoai, k.Email, k.SoDon);
            dgvKhachHang.ClearSelection();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "tải danh sách khách hàng");
        }
        finally
        {
            _dangNap = false;
        }
    }

    private void DgvKhachHang_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dangNap || dgvKhachHang.CurrentRow == null || !dgvKhachHang.CurrentRow.Selected) return;

        int ma = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["MaKH"].Value);
        var k = _dsKhach.FirstOrDefault(x => x.MaKH == ma);
        if (k == null) return;

        _maDangChon = k.MaKH;
        txtMaKH.Text = k.MaKH.ToString();
        txtHoTen.Text = k.HoTen;
        txtSoDienThoai.Text = k.SoDienThoai;
        txtEmail.Text = k.Email ?? "";
    }

    private bool KiemTraHopLe()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            UiHelper.CanhBao("Họ tên không được để trống.");
            txtHoTen.Focus();
            return false;
        }

        // Số điện thoại Việt Nam: bắt đầu bằng 0, tổng 10–11 chữ số
        if (!Regex.IsMatch(txtSoDienThoai.Text.Trim(), @"^0\d{9,10}$"))
        {
            UiHelper.CanhBao("Số điện thoại không hợp lệ (bắt đầu bằng 0, gồm 10–11 chữ số).");
            txtSoDienThoai.Focus();
            return false;
        }

        string email = txtEmail.Text.Trim();
        if (email.Length > 0 && !LaEmailHopLe(email))
        {
            UiHelper.CanhBao("Email không đúng định dạng.");
            txtEmail.Focus();
            return false;
        }
        return true;
    }

    private static bool LaEmailHopLe(string email)
    {
        try
        {
            return new MailAddress(email).Address == email && email.Contains('.');
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private void GanDuLieu(KhachHang k)
    {
        k.HoTen = txtHoTen.Text.Trim();
        k.SoDienThoai = txtSoDienThoai.Text.Trim();
        string email = txtEmail.Text.Trim();
        k.Email = email.Length == 0 ? null : email;
    }

    private async void BtnThem_Click(object? sender, EventArgs e)
    {
        if (!KiemTraHopLe()) return;
        try
        {
            using var db = DbContextHelper.GetContext();

            string sdt = txtSoDienThoai.Text.Trim();
            if (await db.KhachHangs.AnyAsync(k => k.SoDienThoai == sdt))
            {
                UiHelper.CanhBao("Số điện thoại này đã có trong danh sách khách hàng.");
                return;
            }

            var khach = new KhachHang();
            GanDuLieu(khach);
            db.KhachHangs.Add(khach);
            await db.SaveChangesAsync();

            Log.Information("Thêm khách hàng {MaKH} - {HoTen}", khach.MaKH, khach.HoTen);
            UiHelper.ThongBao("Đã thêm khách hàng.");
            LamMoiO();
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "thêm khách hàng");
        }
    }

    private async void BtnSua_Click(object? sender, EventArgs e)
    {
        if (_maDangChon == null)
        {
            UiHelper.CanhBao("Hãy chọn khách hàng cần sửa trong danh sách.");
            return;
        }
        if (!KiemTraHopLe()) return;

        try
        {
            using var db = DbContextHelper.GetContext();
            var khach = await db.KhachHangs.FindAsync(_maDangChon.Value);
            if (khach == null)
            {
                UiHelper.CanhBao("Khách hàng không còn tồn tại.");
                await NapDuLieuAsync();
                return;
            }

            string sdt = txtSoDienThoai.Text.Trim();
            if (await db.KhachHangs.AnyAsync(k => k.SoDienThoai == sdt && k.MaKH != khach.MaKH))
            {
                UiHelper.CanhBao("Số điện thoại này đã thuộc về khách hàng khác.");
                return;
            }

            GanDuLieu(khach);
            await db.SaveChangesAsync();

            Log.Information("Sửa khách hàng {MaKH} - {HoTen}", khach.MaKH, khach.HoTen);
            UiHelper.ThongBao("Đã cập nhật khách hàng.");
            LamMoiO();
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "sửa khách hàng");
        }
    }

    private async void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_maDangChon == null)
        {
            UiHelper.CanhBao("Hãy chọn khách hàng cần xóa trong danh sách.");
            return;
        }

        try
        {
            using var db = DbContextHelper.GetContext();
            var khach = await db.KhachHangs.FindAsync(_maDangChon.Value);
            if (khach == null)
            {
                await NapDuLieuAsync();
                return;
            }

            if (await db.DatTours.AnyAsync(d => d.MaKH == khach.MaKH))
            {
                UiHelper.CanhBao("Khách hàng này đã có đơn đặt tour nên không thể xóa.\nHãy hủy các đơn đặt tour trước.");
                return;
            }

            if (!UiHelper.XacNhan($"Bạn có chắc muốn xóa khách hàng \"{khach.HoTen}\"?")) return;

            db.KhachHangs.Remove(khach);
            await db.SaveChangesAsync();

            Log.Information("Xóa khách hàng {MaKH} - {HoTen}", khach.MaKH, khach.HoTen);
            LamMoiO();
            await NapDuLieuAsync();
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "xóa khách hàng");
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
        txtMaKH.Clear();
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        txtEmail.Clear();
        dgvKhachHang.ClearSelection();
        txtHoTen.Focus();
    }
}
