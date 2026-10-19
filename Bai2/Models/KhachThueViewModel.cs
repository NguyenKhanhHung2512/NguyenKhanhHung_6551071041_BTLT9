using System;

namespace Bai2.Models
{
    public class KhachThueViewModel
    {
        public int MaKhach { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public DateOnly NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public decimal GiaThue { get; set; }
        public string GiaThueFormatted => $"{GiaThue:N0} đ";
        public int MaTinh { get; set; }
        public string TenTinh { get; set; } = string.Empty;
        public int MaPhuongXa { get; set; }
        public string TenPhuongXa { get; set; } = string.Empty;

        public string QueQuan => string.IsNullOrWhiteSpace(TenPhuongXa)
            ? TenTinh
            : $"{TenPhuongXa} - {TenTinh}";

        public bool DaDangKyTamTru { get; set; }
    }

    public class PhongTroDisplayItem
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public decimal GiaThue { get; set; }
        public string TinhTrang { get; set; } = string.Empty;

        public string DisplayText => $"{TenPhong} - {GiaThue:N0} đ";

        public override string ToString() => DisplayText;
    }
}
