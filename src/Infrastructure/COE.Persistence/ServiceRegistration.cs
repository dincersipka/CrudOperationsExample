using COE.Application.Abstractions.Context;
using COE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace COE.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection Services) 
        {
            Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
