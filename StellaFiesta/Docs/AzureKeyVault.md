# Azure KeyVault

In order to use KeyVault for connection string, you need to do several things. I will list them up for you here:

## Create an "App registration" under ActiveDirectory

1. Search for "Active Directory" in Azure
2. Go to the tab "App registrations"
3. Register a new app (+ new application registration)
4. Give it a name (stellafiestaapikode), an application type (Web app /Api), and a random direct url.
5. When you have created it, you can retrieve its "Application id", e.g. "a5e2800d-7da6-4f7c-b3d6-7cc53bdf532x", which will be used as your "clientId" later.
6. Go to its settings, and further to "Keys"
7. Define a new key; name (stellafiesta2), duration (never), and then save the automatically generated value which will come when you save ("clientSecret").

## Create a KeyVault

1. Search for KeyVault and create one, with a name ("stellafiestakeyvault") you will use later.
2. Go to "Secrets" in the blade, and generate a new secret
3. Upload options should be "Manual", and the name should be "appSettings--connectionStrings--stellafiestakode", and the value should be your connectionstring.

## Setup the Api

1. Get the nuget package / or maybe not? Otherwise it is "Microsoft.Extensions.Configuration.AzureKeyVault" or search for "Microsoft keyvault" and take core version.
2. Add a new .json file in the root together with "appsettings.json", with the name "azurekeyvault.json"

```
{
    "azureKeyVault": {
        "vault": "stellafiestakeyvault",
        "clientId": "a5e2800d-7da6-4f7c-b3d6-7cc53bdf532x",
        "clientSecret": "6OnYQ4I9bgJFFR6HJJJwoHZYrIq+XuszvvHRTNRyFg="
    }
}
```

3. Also, add the following code to the git ignore file, otherwise people will snatch it.

```
# Azure
**/azurekeyvault.json
```

4. Add the json file to the configuration in the Program.cs file, and retrieve the information from "azurekeyvault.json" which you need to retrieve the secret from Azure. See code.


```
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

            var vaultName = buildConfig["azureKeyVault:vault"];
            var clientId = buildConfig["azureKeyVault:clientId"];
            var clientSecret = buildConfig["azureKeyVault:clientSecret"];
            var dnsName = $"https://{vaultName}.vault.azure.net/";
            config.AddAzureKeyVault(
                dnsName,
                clientId,
                clientSecret);

            var newBuildConfig = config.Build();

            // In azure: appSettings-connectionStrings-stellaFiestaKey
            var connectionString = newBuildConfig["appSettings:connectionStrings:stellafiestakode"];
        }
```

... that is pretty much it.
