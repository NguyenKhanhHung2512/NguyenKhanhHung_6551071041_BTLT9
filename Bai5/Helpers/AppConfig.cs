using Microsoft.Extensions.Configuration;

namespace Bai5.Helpers;

public static class AppConfig
{
    public static IConfiguration Configuration { get; private set; } = null!;
    public static AppSettings Settings { get; private set; } = new();
    public static ExchangeRateSettings ExchangeRate { get; private set; } = new();

    public static void Initialize()
    {
        string env = Environment.GetEnvironmentVariable("APP_ENVIRONMENT") ?? "Production";

        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        Settings = Configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
        ExchangeRate = Configuration.GetSection("ExchangeRate").Get<ExchangeRateSettings>() ?? new ExchangeRateSettings();
    }

    public static string GetConnectionString()
    {
        return Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
               ?? Configuration.GetConnectionString("DefaultConnection")
               ?? throw new InvalidOperationException("Thiếu ConnectionStrings:DefaultConnection trong appsettings.json.");
    }
}
