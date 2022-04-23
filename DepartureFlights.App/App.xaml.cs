using Business.Services;
using DataBase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DepartureFlights.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>


    public partial class App : Application
    {
        private readonly IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => 
                {
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddTransient<IDatabaseConnection, DatabaseConnection>();
            services.AddTransient<IFligthService, FligthService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAirlineService, AirlineService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IStatusService, StatusService>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e) 
        {
            using (host) 
            {
                await host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
