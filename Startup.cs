using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sistema_Venta_Autos.Models;
using Microsoft.EntityFrameworkCore;
using Sistema_ventas_autos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Sistema_Venta_Autos
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc();
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(
                    "Host=ec2-107-21-120-104.compute-1.amazonaws.com;" +
                    "Database=d1gs229g17d4cs;Username=kpqkivbtuetuum;"+
                    "Password=e09ce762f247089f15d6566ec3c8924ae022213ba3a7d81ae6fc10d1465f719c;"+
                    "Port=5432;SSL Mode=Require;Trust Server Certificate=true")
            );
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DatabaseContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<IdentityOptions>(options =>
                {
                    // Default Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredUniqueChars = 1;
                });

            /*//BASE DE DATOS DE REPUESTO (appdatabaserl)
                services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(
                    "Host=ec2-54-83-9-36.compute-1.amazonaws.com;" +
                    "Database=d8go70du7jsqpe;Username=bilnzpnviagxjp;"+
                    "Password=372d7cfc5d7aa5dd291a0d107e418f4756eb3edfc44d76010c70c44e85646d67;"+
                    "Port=5432;SSL Mode=Require;Trust Server Certificate=true")
            );*/
        }
         


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
