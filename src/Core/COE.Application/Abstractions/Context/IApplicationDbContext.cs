using COE.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace COE.Application.Abstractions.Context
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }

        Task<int> SaveChangesAsync(CancellationToken Token = default);
    }
}
