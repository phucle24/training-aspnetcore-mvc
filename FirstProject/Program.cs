using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstProject.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
namespace FirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedDb(host);
                host.Run();
        }

        private static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope  = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<FirstSeeder>();
                seeder.SeedAsync().Wait();
            }
               
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                            .ConfigureAppConfiguration((context, builder) => builder.SetBasePath(context.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json")
                       .Build())

            .UseStartup<Startup>()
            .Build();
    }
}
