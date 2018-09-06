using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StellaFiesta.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration((context, config) => SetupConfig(context, config))
                    .UseStartup<Startup>()
                    .Build();

        private static void SetupConfig(WebHostBuilderContext context, IConfigurationBuilder config)
        {
            var rootPath = context.HostingEnvironment.ContentRootPath;
            config
                .SetBasePath(rootPath)
                .AddJsonFile("azurekeyvault.json", optional: false, reloadOnChange: true);

            var buildConfig = config.Build();

            var azureName = buildConfig["azureKeyVault:vault"];
            var clientId = buildConfig["azureKeyVault:clientId"];
            var clientSecret = buildConfig["azureKeyVault:clientSecret"];
            var redirectUrl = $"https://{azureName}.vault.azure.net/";
            config.AddAzureKeyVault(
                redirectUrl,
                clientId,
                clientSecret);

            var newBuildConfig = config.Build();

            // In azure: appSettings-connectionStrings-stellaFiestaKey
            var connectionString = newBuildConfig["appSettings:connectionStrings:stellafiestakode"];
        }
    }
}
