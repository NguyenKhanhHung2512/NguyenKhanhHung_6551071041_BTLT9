using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Bai2.Helpers
{
    public static class AppConfig
    {
        public static IConfiguration Configuration { get; private set; } = null!;
        public static AppSettings Settings { get; private set; } = new();

        public static void Initialize()
        {
            string env = Environment.GetEnvironmentVariable("APP_ENVIRONMENT")
                ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                ?? "Development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
            Settings = Configuration.GetSection("AppSettings").Get<AppSettings>() ?? new AppSettings();
        }

        public static string GetConnectionString()
        {
            if (Configuration == null) Initialize();

            return Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                   ?? Configuration?.GetConnectionString("DefaultConnection")
                   ?? "Server=.;Database=QL_NhaTro;Trusted_Connection=True;TrustServerCertificate=True;";
        }
    }
}
