using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Bai1.Configuration
{
    public class ConnectionStringsConfig
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }

    public class AppSettingsConfig
    {
        public string DefaultCulture { get; set; } = "vi-VN";
        public string LogFolder { get; set; } = "Logs";
    }

    public class AppConfig
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; } = new();
        public AppSettingsConfig AppSettings { get; set; } = new();

        private static IConfigurationRoot? _configurationRoot;
        private static AppConfig? _current;
        private static readonly object _lock = new();

        public static AppConfig Current
        {
            get
            {
                if (_current == null)
                {
                    lock (_lock)
                    {
                        _current ??= LoadConfiguration();
                    }
                }
                return _current;
            }
        }

        public static AppConfig LoadConfiguration()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            string? env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
#if DEBUG
            if (string.IsNullOrWhiteSpace(env) && File.Exists(Path.Combine(basePath, "appsettings.Development.json")))
            {
                env = "Development";
            }
#endif

            if (!string.IsNullOrWhiteSpace(env))
            {
                builder.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
            }

            _configurationRoot = builder.Build();
            var config = new AppConfig();
            _configurationRoot.Bind(config);

            if (string.IsNullOrWhiteSpace(config.ConnectionStrings.DefaultConnection))
            {
                config.ConnectionStrings.DefaultConnection = _configurationRoot.GetConnectionString("DefaultConnection") ?? string.Empty;
            }

            _configurationRoot.GetReloadToken().RegisterChangeCallback(_ =>
            {
                lock (_lock)
                {
                    try
                    {
                        var updatedConfig = new AppConfig();
                        _configurationRoot.Bind(updatedConfig);
                        if (string.IsNullOrWhiteSpace(updatedConfig.ConnectionStrings.DefaultConnection))
                        {
                            updatedConfig.ConnectionStrings.DefaultConnection = _configurationRoot.GetConnectionString("DefaultConnection") ?? string.Empty;
                        }
                        _current = updatedConfig;
                    }
                    catch
                    {
                        // Ignore reload errors while file is being written
                    }
                }
            }, null);

            _current = config;
            return config;
        }

        public static void Reload()
        {
            lock (_lock)
            {
                _current = LoadConfiguration();
            }
        }
    }
}
