using CoreModelSeperation.Data;
using CoreModelSeperation.Repogitories.IRepogitory;
using CoreModelSeperation.Repogitories.Repogitory;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModelSeperation.Extensions
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IAuthorRepository, AuthorRepository>();
            //services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}