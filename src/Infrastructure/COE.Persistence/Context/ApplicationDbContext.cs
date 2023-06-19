using COE.Application.Abstractions.Context;
using COE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace COE.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
