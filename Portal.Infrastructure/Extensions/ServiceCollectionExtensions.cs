using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Domain.Repositories;
using Portal.Infrastructure.Persistance;
using Portal.Infrastructure.Repositories;
using Portal.Infrastructure.SeedData;

namespace Portal.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PortalConnection");

            services.AddDbContext<PortalDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IPortalDataSeeder,PortalDataSeeder>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}