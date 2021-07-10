using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minder.Core.Services.Auth;
using Minder.Stores;

namespace Minder.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();

                services.AddTransient<INavigator, Navigator>();
                services.AddTransient<IAuthService, AuthService>();
            });

            return host;
        }
    }
}
