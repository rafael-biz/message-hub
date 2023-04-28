using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.MessageHub;

namespace Application1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static async Task Main()
        {
            var host = CreateHostBuilder().Build();

            await host.StartAsync();

            ApplicationConfiguration.Initialize();

            Application.Run((MainForm)host.Services.GetService(typeof(MainForm)));
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(configs =>
                {
                    configs.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<MainForm>();

                    services.AddMessageHub(context.Configuration);
                });
        }
    }
}