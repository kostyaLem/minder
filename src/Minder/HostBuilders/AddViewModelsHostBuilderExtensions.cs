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
                services.AddTransient<AuthViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddTransient<EquipmentViewModel>();
                services.AddTransient<SoftwareViewModel>();
                services.AddTransient<StaffViewModel>();
            });

            return hostBuilder;
        }
    }
}
