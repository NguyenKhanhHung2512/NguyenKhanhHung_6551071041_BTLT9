using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using Bai3.Helpers;

namespace Bai3.Services;

public sealed record WeatherForecast(int Code, double Max, double Min, int Rain, string Description);
public sealed record Location(double Latitude, double Longitude, string Name);
public sealed class LocationNotFoundException : Exception
{
    public LocationNotFoundException(string place) : base($"No location matched '{place}'.") { }
}

public static class WeatherService
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(Math.Clamp(AppConfig.Settings.ApiTimeoutSeconds, 1, 30)) };

    public static async Task<WeatherForecast?> GetForecastAsync(string place, DateTime date, string language)
    {
        string lang = language == "en" ? "en" : "vi";
        var loc = await FindLocationAsync(place, lang);
        if (loc is null) throw new LocationNotFoundException(place);
        string url = $"{AppConfig.Settings.ForecastApiUrl}?latitude={loc.Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={loc.Longitude.ToString(CultureInfo.InvariantCulture)}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=auto&forecast_days=16";
        using var response = await Http.GetAsync(url);
        response.EnsureSuccessStatusCode();
        using var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var daily = json.RootElement.GetProperty("daily");
        var times = daily.GetProperty("time");
        int index = -1;
        for (int i = 0; i < times.GetArrayLength(); i++)
            if (DateOnly.TryParse(times[i].GetString(), out var day) && day == DateOnly.FromDateTime(date)) { index = i; break; }
        if (index < 0) return null;
        int code = daily.GetProperty("weather_code")[index].GetInt32();
        double max = daily.GetProperty("temperature_2m_max")[index].GetDouble();
        double min = daily.GetProperty("temperature_2m_min")[index].GetDouble();
        int rain = daily.GetProperty("precipitation_probability_max")[index].ValueKind == JsonValueKind.Number ? daily.GetProperty("precipitation_probability_max")[index].GetInt32() : 0;
        return new WeatherForecast(code, max, min, rain, Description(code, lang));
    }

    private static async Task<Location?> FindLocationAsync(string place, string language)
    {
        string url = $"{AppConfig.Settings.GeocodingApiUrl}?name={Uri.EscapeDataString(place)}&count=1&language={language}&format=json";
        using var response = await Http.GetAsync(url);
        response.EnsureSuccessStatusCode();
        using var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        if (!json.RootElement.TryGetProperty("results", out var results) || results.GetArrayLength() == 0) return null;
        var first = results[0];
        return new Location(first.GetProperty("latitude").GetDouble(), first.GetProperty("longitude").GetDouble(), first.GetProperty("name").GetString() ?? place);
    }

    public static string IconFor(int code) => code switch { 0 => "☀️", 1 or 2 => "🌤️", 3 => "☁️", 45 or 48 => "🌫️", 51 or 53 or 55 or 56 or 57 => "🌦️", >= 61 and <= 67 => "🌧️", >= 71 and <= 77 => "❄️", >= 80 and <= 82 => "🌧️", 95 or 96 or 99 => "⛈️", _ => "🌥️" };

    private static string Description(int code, string language) => (language, code) switch
    {
        ("en", 0) => "Clear sky", ("en", 1) => "Mainly clear", ("en", 2) => "Partly cloudy", ("en", 3) => "Overcast",
        ("en", 45 or 48) => "Fog", ("en", 51 or 53 or 55) => "Drizzle", ("en", 56 or 57) => "Freezing drizzle",
        ("en", >= 61 and <= 67) => "Rain", ("en", >= 71 and <= 77) => "Snow", ("en", >= 80 and <= 82) => "Rain showers", ("en", >= 95) => "Thunderstorm",
        (_, 0) => "Trời quang", (_, 1) => "Ít mây", (_, 2) => "Có mây", (_, 3) => "Nhiều mây",
        (_, 45 or 48) => "Sương mù", (_, 51 or 53 or 55) => "Mưa phùn", (_, 56 or 57) => "Mưa phùn đóng băng",
        (_, >= 61 and <= 67) => "Mưa", (_, >= 71 and <= 77) => "Tuyết", (_, >= 80 and <= 82) => "Mưa rào", (_, >= 95) => "Dông", _ => "Thời tiết thay đổi"
    };
}
