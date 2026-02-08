using CoreModelSeperation.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreModelSeperation.Extensions
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}