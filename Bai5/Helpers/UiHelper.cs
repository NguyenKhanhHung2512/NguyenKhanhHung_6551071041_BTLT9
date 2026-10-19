using Serilog;

namespace Bai5.Helpers;

/// <summary>Các hộp thoại dùng chung.</summary>
public static class UiHelper
{
    public static void ThongBao(string noiDung) =>
        MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void CanhBao(string noiDung) =>
        MessageBox.Show(noiDung, "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static bool XacNhan(string noiDung) =>
        MessageBox.Show(noiDung, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    /// <summary>Ghi log mức Error và báo lỗi thân thiện khi thao tác với CSDL thất bại.</summary>
    public static void LoiCsdl(Exception ex, string thaoTac)
    {
        Log.Error(ex, "Lỗi CSDL khi {ThaoTac}", thaoTac);
        MessageBox.Show(
            $"Không thể {thaoTac}.\nVui lòng kiểm tra kết nối cơ sở dữ liệu (chi tiết đã được ghi vào thư mục Logs).",
            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
