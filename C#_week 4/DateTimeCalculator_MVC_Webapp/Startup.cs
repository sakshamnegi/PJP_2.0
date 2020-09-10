using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateTimeCalculator_MVC_Webapp.Data;
using DateTimeCalculator_MVC_Webapp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DateTimeCalculator_MVC_Webapp
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
            // services.AddDistributedMemoryCache();
            // services.AddSession();
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddDbContext<CalculationsDbContext>(option=> option.UseNpgsql(Configuration.GetConnectionString("PostgresConnectionString")));
            services.AddScoped<IRepository,CalculationsRepository>();
            services.AddScoped<IDateCalculator, DateCalculator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CalculationsDbContext calculationsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            calculationsDbContext.Database.EnsureCreated();
        }
    }
}
