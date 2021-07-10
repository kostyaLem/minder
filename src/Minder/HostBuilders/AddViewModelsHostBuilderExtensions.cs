using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minder.ViewModels;
using Minder.ViewModels.Auth;

namespace Minder.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<AuthViewModel>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<EquipmentViewModel>();
                services.AddSingleton<SoftwareViewModel>();
                services.AddSingleton<StaffViewModel>();
            });

            return hostBuilder;
        }
    }
}
