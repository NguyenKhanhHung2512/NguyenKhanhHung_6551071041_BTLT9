using Bai2.Helpers;
using Serilog;
using System;
using System.Windows.Forms;

namespace Bai2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                // Khởi tạo cấu hình strongly-typed và ghi log Serilog
                AppConfig.Initialize();
                LogHelper.Initialize();

                ApplicationConfiguration.Initialize();

                // 7. Xử lý lỗi toàn cục: Application.ThreadException và AppDomain.UnhandledException
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                Application.ThreadException += (sender, e) =>
                {
                    Log.Error(e.Exception, "Lỗi UI Thread chưa được xử lý (Global ThreadException)");
                    MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                {
                    var ex = e.ExceptionObject as Exception;
                    Log.Fatal(ex, "Lỗi nghiêm trọng AppDomain chưa được xử lý (Global UnhandledException)");
                    MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Lỗi nghiêm trọng",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                Application.Run(new FormKhachThue());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng không thể khởi động");
                MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.\n\n" + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LogHelper.Shutdown();
            }
        }
    }
}