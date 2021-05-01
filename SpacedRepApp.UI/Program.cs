using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SpacedRepApp.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.AddEnvironmentVariables().Build();
                        var connection = settings.GetConnectionString("ConfigurationConnectionString");
                        config.AddAzureAppConfiguration(connection);
                    }).UseStartup<Startup>();
                });
    }
}
