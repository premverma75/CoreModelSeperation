using CoreModelSeperation.Service.Implementation;
using CoreModelSeperation.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModelSeperation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
        this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}