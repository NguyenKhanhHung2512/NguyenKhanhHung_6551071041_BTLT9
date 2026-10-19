using Bai3.Helpers;
using Serilog;

namespace Bai3;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        try
        {
            AppConfig.Initialize();
            LogHelper.Initialize();
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) =>
            {
                Log.Error(e.Exception, "Unhandled UI exception");
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            AppDomain.CurrentDomain.UnhandledException += (_, e) => Log.Fatal(e.ExceptionObject as Exception, "Unhandled application exception");
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application startup failed");
            MessageBox.Show("Không thể khởi động ứng dụng. Hãy kiểm tra cấu hình và file log.", "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally { Log.CloseAndFlush(); }
    }
}
