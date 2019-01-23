﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            var connectionString = "Server=tcp:quickstart.database.windows.net,1433;Initial Catalog=StellaFiestaDB;Persist Security Info=False;User ID=mathias;Password=Stella4ever;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<StellaFiestaContext>(opt =>
             {
                 opt.UseSqlServer(connectionString);
             });

            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddApplicationInsightsTelemetry(Configuration);

            ////services.Configure<CookiePolicyOptions>(options =>
            ////{
            ////    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            ////    options.CheckConsentNeed.ed = context => false;
            ////    options.MinimumSameSitePolicy = SameSiteMode.None;
            ////});

            ////services.AddMvc()
            ////.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddApplicationInsights(app.ApplicationServices, LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseMvc();
        }
    }
}
