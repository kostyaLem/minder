using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minder.ViewModels;
using Minder.ViewModels.Auth;
using Minder.Views;

namespace Minder.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                services.AddSingleton<AuthView>(s => new AuthView(s.GetRequiredService<AuthViewModel>()));
            });

            return host;
        }
    }
}
