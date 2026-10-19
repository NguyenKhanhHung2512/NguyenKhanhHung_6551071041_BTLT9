using System.Globalization;

namespace Bai5.Helpers;

/// <summary>Định dạng tiền, tỷ giá, ngày theo kiểu Việt Nam.</summary>
public static class DinhDang
{
    public static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    public static string Tien(decimal soTien) => soTien.ToString("N0", Vi) + " đ";

    public static string NgoaiTe(decimal soTien, string maNgoaiTe) => soTien.ToString("#,##0.##", Vi) + " " + maNgoaiTe;

    public static string TyGia(decimal tyGia) => tyGia.ToString("#,##0.####", Vi);

    public static string Ngay(DateOnly ngay) => ngay.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

    public static string NgayGio(DateTime ngay) => ngay.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
}
