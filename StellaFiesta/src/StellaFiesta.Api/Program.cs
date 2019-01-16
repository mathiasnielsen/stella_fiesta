using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace StellaFiesta.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        // TODO:
        // https://docs.microsoft.com/da-dk/aspnet/core/host-and-deploy/iis/troubleshoot?view=aspnetcore-2.2

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                    ////.ConfigureAppConfiguration((context, config) => SetupConfig(context, config))
                    .UseStartup<Startup>()
                    .Build();

        private static void SetupConfig(WebHostBuilderContext context, IConfigurationBuilder config)
        {
            var rootPath = context.HostingEnvironment.ContentRootPath;
            config
                .SetBasePath(rootPath)
                .AddJsonFile("azurekeyvault.json", optional: false, reloadOnChange: true);

            var buildConfig = config.Build();

            var vaultName = buildConfig["azureKeyVault:vault"];
            var clientId = buildConfig["azureKeyVault:clientId"];
            var clientSecret = buildConfig["azureKeyVault:clientSecret"];
            var dnsName = $"https://{vaultName}.vault.azure.net/";
            config.AddAzureKeyVault(
                dnsName,
                clientId,
                clientSecret);

            var newBuildConfig = config.Build();
        }
    }
}
