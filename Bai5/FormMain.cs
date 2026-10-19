using Bai5.Helpers;
using Serilog;

namespace Bai5;

public partial class FormMain : Form
{
    public FormMain()
    {
        InitializeComponent();
        // Hiển thị phiên bản trên thanh tiêu đề
        Text = $"Quản lý đặt tour - v{AppInfo.Version}";
    }

    private async void FormMain_Load(object? sender, EventArgs e)
    {
        // Kiểm tra kết nối CSDL một lần, báo lỗi thân thiện thay vì văng 3 lần ở 3 tab
        try
        {
            using var db = DbContextHelper.GetContext();
            if (!await db.Database.CanConnectAsync())
            {
                Log.Error("Không kết nối được CSDL với connection string hiện tại");
                UiHelper.CanhBao("Không kết nối được cơ sở dữ liệu QL_DatTour.\n\n" +
                                 "Hãy kiểm tra SQL Server đã chạy và sửa ConnectionStrings trong file appsettings.json " +
                                 "(nằm cạnh file .exe), sau đó mở lại ứng dụng.");
                return;
            }
        }
        catch (Exception ex)
        {
            UiHelper.LoiCsdl(ex, "kết nối cơ sở dữ liệu");
            return;
        }

        await ucTour.NapDuLieuAsync();
        await ucKhachHang.NapDuLieuAsync();
        await ucDatTour.NapDuLieuAsync();
    }

    private async void TabChinh_SelectedIndexChanged(object? sender, EventArgs e)
    {
        // Dữ liệu ở tab này có thể đã đổi do thao tác ở tab khác → nạp lại khi chuyển tab
        if (tabChinh.SelectedTab == tabTour)
            await ucTour.NapDuLieuAsync();
        else if (tabChinh.SelectedTab == tabKhachHang)
            await ucKhachHang.NapDuLieuAsync();
        else if (tabChinh.SelectedTab == tabDatTour)
            await ucDatTour.NapDuLieuAsync();
    }
}
