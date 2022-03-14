using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minder.Core.Services.Auth;
using Minder.DomainModels.Context;
using Minder.ViewModels;
using Minder.ViewModels.Auth;
using Minder.ViewModels.Base;
using Minder.Views;
using System.Windows;

namespace Minder
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider;

        public App()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=minderdb;Trusted_Connection=True";
            services.AddDbContext<MinderDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddSingleton<AuthViewModel>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<TitleViewModel, EquipmentViewModel>();
            services.AddSingleton<TitleViewModel, SoftwareViewModel>();
            services.AddSingleton<TitleViewModel, StaffViewModel>();

            services.AddSingleton<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            new AuthView().Show();

            //var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            //mainWindow.DataContext = ServiceProvider.GetRequiredService<MainViewModel>();
            //mainWindow.Show();
        }
    }

    public static class ViewModelLocator
    {
        public static AuthViewModel AuthViewModel => 
            App.ServiceProvider.GetRequiredService<AuthViewModel>();
    }
}
