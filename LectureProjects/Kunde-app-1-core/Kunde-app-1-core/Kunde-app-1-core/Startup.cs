using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kunde_app_1_core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kunde_app_1_core
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
            services.AddMvc();
            // databasen blir fysisk liggende på /user/tor -- bør finne en en annen mappe!
            // bruk view -> SQL Object Explorer for å aksessere databasen direkte.
            var connection = @"Server=(localdb)\mssqllocaldb;Database=Kunde2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<KundeContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Kunde}/{action=Liste}/{id?}");
            });
        }
    }
}
