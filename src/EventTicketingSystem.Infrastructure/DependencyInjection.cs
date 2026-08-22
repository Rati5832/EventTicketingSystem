using EventTicketingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventTicketingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString == null)
            {
                throw new InvalidOperationException("Connection string not found.");
            }

            return services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(connectionString)
            );
        }
    }
}
