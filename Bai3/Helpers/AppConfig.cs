using Microsoft.Extensions.Configuration;

namespace Bai3.Helpers;

public sealed class AppSettings
{
    public string DefaultCulture { get; set; } = "vi-VN";
    public string LogFolder { get; set; } = "Logs";
    public string GeocodingApiUrl { get; set; } = "https://geocoding-api.open-meteo.com/v1/search";
    public string ForecastApiUrl { get; set; } = "https://api.open-meteo.com/v1/forecast";
    public int ApiTimeoutSeconds { get; set; } = 8;
}

public static class AppConfig
{
    private static IConfiguration? _configuration;
    public static AppSettings Settings { get; private set; } = new();

    public static void Initialize()
    {
        string env = Environment.GetEnvironmentVariable("APP_ENVIRONMENT") ?? "Production";
        _configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables().Build();
        Settings = _configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
    }

    public static string GetConnectionString() => Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
        ?? _configuration?.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Missing ConnectionStrings:DefaultConnection in appsettings.json.");
}
