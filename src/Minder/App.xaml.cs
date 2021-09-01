using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minder.DomainModels.Context;
using Minder.HostBuilders;
using System.Windows;

namespace Minder
{
    public partial class App : Application
    {
        private static readonly IHost _host;

        static App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                       .AddDbContext()
                       .AddServices()
                       .AddViewModels()
                       .AddViews();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            MinderDbContextFactory contextFactory = _host.Services.GetRequiredService<MinderDbContextFactory>();
            using var context = contextFactory.CreateDbContext();
            context.Database.Migrate();

            var authView = _host.Services.GetRequiredService<MainWindow>();
            authView.ShowDialog();

            base.OnStartup(e);

            _host.WaitForShutdown();
        }

        public static T Resolve<T>() => _host.Services.GetRequiredService<T>();
    }
}
