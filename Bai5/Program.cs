using System.Globalization;
using Bai5.Helpers;
using Serilog;

namespace Bai5;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        try
        {
            // 1) Đọc appsettings.json  2) Khởi tạo Serilog
            AppConfig.Initialize();
            LogHelper.Initialize();

            // Định dạng ngày / tiền theo tiếng Việt
            var culture = new CultureInfo(AppConfig.Settings.DefaultCulture);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // 3) Bắt lỗi toàn cục
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
            {
                Log.Error(e.Exception, "Lỗi chưa được xử lý trên UI thread");
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Log.Fatal(e.ExceptionObject as Exception, "Lỗi nghiêm trọng – ứng dụng sắp đóng");
                Log.CloseAndFlush();
                MessageBox.Show("Đã xảy ra lỗi nghiêm trọng, thông tin đã được ghi lại.", "Lỗi nghiêm trọng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            TaskScheduler.UnobservedTaskException += (s, e) =>
            {
                Log.Error(e.Exception, "Lỗi trong tác vụ nền chưa được xử lý");
                e.SetObserved();
            };

            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Không thể khởi động ứng dụng");
            MessageBox.Show("Không thể khởi động ứng dụng:\n\n" + ex.Message, "Lỗi khởi động",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            LogHelper.Shutdown();
        }
    }
}
