using Microsoft.EntityFrameworkCore;
using System;

namespace Minder.DomainModels.Context
{
    public class MinderDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public MinderDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public MinderDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<MinderDbContext> options = new DbContextOptionsBuilder<MinderDbContext>();

            _configureDbContext(options);

            return new MinderDbContext(options.Options);
        }
    }
}
