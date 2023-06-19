using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace COE.Persistence
{
    static class Configuration
    {
        public static string? ConnectionString
        {
            get
            {
                ConfigurationManager Configuration = new ConfigurationManager();

                try
                {
                    Configuration.SetBasePath(Directory.GetCurrentDirectory());
                    Configuration.AddJsonFile("appsettings.json");
                }
                catch
                {
                    Configuration.AddJsonFile("appsettings.Production.json");
                }

                return Configuration.GetConnectionString("SqlServer");
            }
        }
    }
}
