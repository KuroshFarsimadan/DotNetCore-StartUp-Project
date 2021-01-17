using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project_Skeleton.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
            var host = CreateHostBuilder(args).Build();
            var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seeder.UsersSeeder(context);
            }
            catch (Exception exception)
            {
                var logging = services.GetRequiredService<ILogger<Program>>();
                logging.LogError(exception, "Test data migration error");
            }
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfiguration(HostBuilderContext hbc, IConfigurationBuilder icb)
        {
            // Remove configuration
            // icb.Sources.Clear();
            // icb.AddJsonFile("development-configuration.json", false, true).AddEnvironmentVariables();
            // icb.AddJsonFile("production-configuration.json", false, true).AddEnvironmentVariables();
        }
    }
}
