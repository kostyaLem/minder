using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minder.DomainModels.Context;
using Minder.HostBuilders;
using Minder.Stores;
using Minder.ViewModels;
using Minder.ViewModels.Base;
using Minder.Views;
using System.Collections.Generic;
using System.Windows;

namespace Minder
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public static ViewModelLocator ViewModelLocator { get; private set; }

        public App()
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

            var authView = _host.Services.GetRequiredService<AuthView>();
            authView.Show();

            var viewModels = new Dictionary<ViewType, TitleViewModel>
            {
                [ViewType.EquipmentView] = new EquipmentViewModel(),
                [ViewType.SoftwareView] = new SoftwareViewModel(),
                [ViewType.StaffView] = new StaffViewModel()
            };

            base.OnStartup(e);
        }
    }
}
