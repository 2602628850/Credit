using Microsoft.Extensions.Configuration;

namespace Data.Core
{
    public static class JsonFileService
    {
        public static void LoadJsonFile(this IConfigurationBuilder builder)
        {
            var envConf = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddEnvironmentVariables().Build();

            var appsettingsName = envConf["SETTING_JSON"];

            
            builder.AddJsonFile(appsettingsName,false);
        }
    }
}