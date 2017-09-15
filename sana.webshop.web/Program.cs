using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using sana.webshop.web.Initialize;
using sana.webshop.web.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace sana.webshop.web.web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                 .UseKestrel()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                 .UseIISIntegration()
                 .UseStartup<Startup>()
                 .UseApplicationInsights()
                 .Build();

            DatabaseInitializer(host);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void DatabaseInitializer(IWebHost host) {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<EFContext>();
                    WebshopInitialize.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
