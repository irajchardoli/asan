using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASAN.DataLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;
using System.Security.Claims;

namespace ASAN.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ASAN.Services.Contracts.IOwnerService, ASAN.Services.OwnerService>();
            services.AddScoped<ASAN.Services.Contracts.IEstateService, ASAN.Services.EstateService>();

            services.AddEntityFrameworkSqlServer();

            services.AddDbContextPool<ApplicationDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AsanConnection")
                        , serverDbContextOptionsBuilder =>
                        {
                            var minutes = (int)TimeSpan.FromMinutes(60).TotalSeconds;
                            serverDbContextOptionsBuilder.CommandTimeout(minutes);
                            serverDbContextOptionsBuilder.EnableRetryOnFailure();
                        });

                optionsBuilder.UseInternalServiceProvider(serviceProvider);

            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
                SeedData(context);
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Dashboard/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Estate}/{action=Index}/{id?}");
            });
        }

        public void SeedData(ApplicationDbContext context)
        {
            if (!context.Owners.Any())
            {
                context.Add(new ASAN.Entities.Owner(firstName: "Ali" ,lastName: "Aslani" ,phoneNumber: "021-9999"));
                context.Add(new ASAN.Entities.Owner(firstName: "Mehdi" ,lastName: "fatemi" ,phoneNumber: "021-8888"));
                context.Add(new ASAN.Entities.Owner(firstName: "Reza" ,lastName: "hashemi" ,phoneNumber: "021-7777"));
                context.Add(new ASAN.Entities.Owner(firstName: "Saman" ,lastName: "sabri" ,phoneNumber: "021-6666"));
                context.Add(new ASAN.Entities.Owner(firstName: "Milad" ,lastName: "razavi" ,phoneNumber: "021-5555"));
                context.Add(new ASAN.Entities.Owner(firstName: "Farzad" ,lastName: "soltani" ,phoneNumber: "021-4444"));
                context.SaveChanges();
            }
        }
    }
}
