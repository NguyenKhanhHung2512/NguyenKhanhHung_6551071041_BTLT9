using System.Text.Json;

namespace Bai3.Helpers;

public static class UserSettings
{
    private static string SettingsPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KeHoachDaNgoai", "usersettings.json");

    public static string LoadLanguage()
    {
        try
        {
            if (File.Exists(SettingsPath))
            {
                using var doc = JsonDocument.Parse(File.ReadAllText(SettingsPath));
                if (doc.RootElement.TryGetProperty("Culture", out var value) && value.GetString() == "en") return "en";
            }
        }
        catch { }
        return "vi";
    }

    public static void SaveLanguage(string language)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath)!);
            File.WriteAllText(SettingsPath, JsonSerializer.Serialize(new { Culture = language }, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch (Exception ex) { Serilog.Log.Warning(ex, "Could not persist language preference"); }
    }
}
