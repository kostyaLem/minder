using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Minder.DomainModels.Context
{
    public class MinderDbContextFactory : IDesignTimeDbContextFactory<MinderContext>
    {
        public MinderContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MinderContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=minderdb;Trusted_Connection=True");

            return new MinderContext(optionsBuilder.Options);
        }
    }
}
