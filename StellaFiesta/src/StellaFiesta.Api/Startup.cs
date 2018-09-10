using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;

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

            var account = new CloudStorageAccount(
                new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(
                    "<storage-accountname>",
                    "<storage-accountkey>"), true);

            ////var connectionString = Configuration["appSettings:connectionStrings:stellafiestakode"];
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
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
