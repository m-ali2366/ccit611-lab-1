using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Configurations.Localizations
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddLocalizationWithCache(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddScoped<LocalizationMiddleware>();
            services.AddScoped<JsonStringLocalizer>();
            return services;
        }
    }
}
