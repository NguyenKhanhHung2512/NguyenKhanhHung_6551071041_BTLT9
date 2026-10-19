using Bai5.Helpers;

namespace Bai5.Models;

// Các lớp dùng để hiển thị (không phải entity) – tách riêng để không bị ghi đè khi scaffold lại

/// <summary>Một dòng tour kèm số chỗ đã đặt (dùng cho lưới Tour và ComboBox tour).</summary>
public class TourItem
{
    public int MaTour { get; set; }
    public string TenTour { get; set; } = "";
    public string DiemDen { get; set; } = "";
    public string NgoaiTe { get; set; } = "";
    public decimal GiaNgoaiTe { get; set; }
    public DateOnly NgayKhoiHanh { get; set; }
    public int SoChoToiDa { get; set; }
    public int DaDat { get; set; }

    public int ConLai => SoChoToiDa - DaDat;
    public string HienThi => $"{TenTour} [{NgoaiTe}] – {DinhDang.Ngay(NgayKhoiHanh)}";
}

/// <summary>Một dòng khách hàng kèm số đơn đã đặt.</summary>
public class KhachHangItem
{
    public int MaKH { get; set; }
    public string HoTen { get; set; } = "";
    public string SoDienThoai { get; set; } = "";
    public string? Email { get; set; }
    public int SoDon { get; set; }

    public string HienThi => $"{HoTen} – {SoDienThoai}";
}

/// <summary>Một dòng kết quả JOIN DatTour – KhachHang – Tour.</summary>
public class DatTourDong
{
    public int MaDat { get; set; }
    public string HoTen { get; set; } = "";
    public string TenTour { get; set; } = "";
    public string NgoaiTe { get; set; } = "";
    public DateOnly NgayKhoiHanh { get; set; }
    public int SoNguoi { get; set; }
    public decimal TyGia { get; set; }
    public decimal TongTienVND { get; set; }
    public DateTime NgayDat { get; set; }
}
