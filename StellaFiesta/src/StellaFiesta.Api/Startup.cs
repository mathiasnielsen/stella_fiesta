using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System.Configuration;

namespace StellaFiesta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Old hat.
            ////var connectionString = CloudConfigurationManager.

            // Maybe something?
            ////var account = new CloudStorageAccount(
            ////new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
            ////"<storage-accountname>",
            ////"<storage-accountkey>"), true);

            ////var connectionString = Configuration["appSettings:connectionStrings:stellafiestakode"];
            ////var connectionString = Configuration.GetConnectionString("DefaultConnection");

#if DEBUG
            var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            var connectionStringTest = ConfigurationManager.
#else
            var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
#endif

            services.AddDbContext<StellaFiestaContext>(opt =>
                opt.UseSqlServer(connectionString));

            services.AddMvc();

            ////services.AddMvc()
            ////.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
