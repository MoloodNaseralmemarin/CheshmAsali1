using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CheshmAsali.Domain.Data;
using CheshmAsali.Infrastructure.Common.Repositories;
using CheshmAsali.Infrastructure.Communication.Services.Customers;
using CheshmAsali.Domain.Data.Interfaces;
using CheshmAsali.Domain.Models;
using CheshmAsali.Desktop.ViewModels;
using CheshmAsali.Desktop.Views;
using CheshmAsali.Infrastructure.Communication.Interfaces;
using System.IO;
using System.Windows;

namespace CheshmAsali.Desktop
{
    public partial class App : Application
    {
        private static IHost _host;

        public static IHost Host => _host ??= CreateHostBuilder().Build();

        private static IHostBuilder CreateHostBuilder()
        {
            return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                          .AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("CheshmAsaliConnection");

                    services.AddDbContext<CheshmAsaliDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
                    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
                    services.AddScoped<ICustomerRepository, CustomerRepository>();

                    services.AddSingleton<RegisterViewModel>();
                    services.AddTransient<RegisterWindow>();
                });
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Host.StartAsync();
            var mainWindow = Host.Services.GetRequiredService<RegisterWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await Host.StopAsync();
            Host.Dispose();
            base.OnExit(e);
        }


    }
}
