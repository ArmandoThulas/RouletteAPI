using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RouletteAPI.Service
{
    public static class RouletteAppSettings
    {
        private static readonly IConfiguration Configuration = GetCurrentSettings();

        private static IConfigurationRoot GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
            return builder.Build();
        }
                
        public static string GetConnectionString(string connectionId)
        {
            return Configuration.GetConnectionString(connectionId);
        }

        public static string GetAppSetting(string key)
        {
            var setting = Configuration.GetSection(key);
            return setting.Value?? "";
        }
    }
}
