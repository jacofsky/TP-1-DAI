using System;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace TP_1_DAI.Helpers
{
    public static class ConfigurationHelper 
    {
        public static IConfiguration GetConfiguration() {
            IConfiguration config;

            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            config = builder.Build();
            return config;
                                                  
        }
    }
}