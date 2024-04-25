using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EntitiesContext>();
            services.AddScoped(typeof(Repository<>));
            services.AddScoped<TransactionMiddleware>();
            return services;
        }
    }
}
