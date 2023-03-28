using CryptoCurrency.ApiClients;
using CryptoCurrency.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;
using System.Text;
using System.Windows;

namespace CryptoCurrency
{    
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ServiceCollection serviceCollection = new();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Verbose()
            .WriteTo.File
            (
                configuration["Log"]!,
                rollingInterval: RollingInterval.Day,
                rollOnFileSizeLimit: true,
                restrictedToMinimumLevel: LogEventLevel.Verbose
            )
            .CreateLogger();
                  

            services.AddTransient(sp => configuration);
            services.AddHttpClient();

            services.AddSingleton<IApiClient, CoinCapApiClient>();
            services.AddSingleton(Log.Logger);

            services.AddTransient(typeof(MainWindow));
        }
    }
}
