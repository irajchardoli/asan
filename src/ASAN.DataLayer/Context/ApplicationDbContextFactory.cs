using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ASAN.DataLayer.Context
{
    /// <summary>
    /// Only used by EF Tooling
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerFactory, LoggerFactory>();

            var basePath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Using `{basePath}` as the ContentRootPath");
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(basePath)
                                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false)
                                .Build();
            services.AddSingleton<IConfigurationRoot>(provider => configuration);

            services.AddEntityFrameworkSqlServer();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(
                        configuration.GetConnectionString("AsanConnection")
                        , serverDbContextOptionsBuilder =>
                        {
                            var minutes = (int)TimeSpan.FromMinutes(60).TotalSeconds;
                            serverDbContextOptionsBuilder.CommandTimeout(minutes);
                            serverDbContextOptionsBuilder.EnableRetryOnFailure();
                        });

            optionsBuilder.UseInternalServiceProvider(services.BuildServiceProvider()); // It's added to access services from the dbcontext, remove it if you are using the normal `AddDbContext` and normal constructor dependency injection.

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
