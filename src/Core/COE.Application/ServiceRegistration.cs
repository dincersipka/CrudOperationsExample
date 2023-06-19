using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace COE.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection Services) 
        {
            Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();

            Services.AddAutoMapper(Assemblies);
            Services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assemblies));
        }
    }
}
