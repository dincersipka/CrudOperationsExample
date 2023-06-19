using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace COE.Persistence.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ApplicationDbContext> Builder = new();

            Builder.UseSqlServer(Configuration.ConnectionString);

            return new(Builder.Options);
        }
    }
}
