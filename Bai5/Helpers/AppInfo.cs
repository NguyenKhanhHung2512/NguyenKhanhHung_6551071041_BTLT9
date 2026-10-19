using System.Reflection;

namespace Bai5.Helpers;

public static class AppInfo
{
    /// <summary>Phiên bản lấy từ &lt;Version&gt; trong .csproj, dạng 1.0.0.</summary>
    public static string Version =>
        Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";
}
