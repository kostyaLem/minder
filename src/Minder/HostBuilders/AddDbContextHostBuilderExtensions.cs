using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minder.DomainModels.Context;
using System;

namespace Minder.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=minderdb;Trusted_Connection=True";
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);

                services.AddDbContext<MinderDbContext>(configureDbContext);
                services.AddSingleton<MinderDbContextFactory>(new MinderDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
