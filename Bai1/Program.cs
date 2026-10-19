using System;
using System.IO;
using System.Windows.Forms;
using Serilog;

namespace Bai1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1. Cấu hình đường dẫn thư mục Logs cạnh file .exe
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string logFilePath = Path.Combine(logDirectory, "log-.txt");

            // 2. Khởi tạo Serilog ghi file theo ngày (log-yyyyMMdd.txt)
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    path: logFilePath,
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            Log.Information("Ứng dụng Sổ chi tiêu cá nhân đã khởi động.");

            try
            {
                Application.Run(new FormChiTieu());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Ứng dụng bị dừng đột ngột do lỗi không xử lý được.");
                MessageBox.Show("Đã xảy ra lỗi nghiêm trọng ngoài dự kiến: " + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Log.Information("Ứng dụng Sổ chi tiêu cá nhân đã đóng.");
                Log.CloseAndFlush();
            }
        }
    }
}