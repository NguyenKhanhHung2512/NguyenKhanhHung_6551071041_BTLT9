using Serilog;

namespace Bai3.Helpers;

public static class LogHelper
{
    public static void Initialize()
    {
        string folder = Path.Combine(AppContext.BaseDirectory, AppConfig.Settings.LogFolder);
        Directory.CreateDirectory(folder);
        Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
            .WriteTo.File(Path.Combine(folder, "log-.txt"), rollingInterval: RollingInterval.Day, retainedFileCountLimit: 30,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
        Log.Information("Application started. Version {Version}", typeof(Program).Assembly.GetName().Version);
    }
}
