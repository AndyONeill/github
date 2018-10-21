using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using MannIsland.Services;
using Microsoft.Extensions.Configuration;

namespace MannIsland
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        public IServiceCollection Services { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // DI inject the one instance of Validator with parameter
            // This will be picked up by any controller has IValidator as a ctor parameter
            services.AddSingleton<IValidator>(s => new Validator(Environment.ContentRootPath));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                       //routes.MapRoute(
                       //name: "default",
                       //template: "{controller=Home}/{action=Index}");
                       name: "Validate",
                       template: "{controller}/{action}/{SortCode?}/{AccountNo?}");
                routes.MapRoute(name: null, template: "API/{controller}/{action}");
            });

        }
    }
}
