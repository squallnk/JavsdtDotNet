using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Javasdt.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder host = Host.CreateDefaultBuilder(args);

            host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddUserSecrets<Startup>();
            })
                .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder
                       .UseUrls("http://0.0.0.0:9000")
                       .UseStartup<Startup>();
               });

            return host;
        }
    }
}
