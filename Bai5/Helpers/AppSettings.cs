namespace Bai5.Helpers;

/// <summary>Mục "AppSettings" trong appsettings.json.</summary>
public class AppSettings
{
    public string DefaultCulture { get; set; } = "vi-VN";
    public string LogFolder { get; set; } = "Logs";
}

/// <summary>Mục "ExchangeRate" trong appsettings.json (lớp cấu hình có kiểu).</summary>
public class ExchangeRateSettings
{
    // {code} sẽ được thay bằng mã ngoại tệ viết thường, ví dụ thb
    public string PrimaryUrl { get; set; } = "https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@latest/v1/currencies/{code}.json";
    public string FallbackUrl { get; set; } = "https://latest.currency-api.pages.dev/v1/currencies/{code}.json";
    public int TimeoutSeconds { get; set; } = 10;
    public int CacheMinutes { get; set; } = 10;
}
