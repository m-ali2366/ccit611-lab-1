using Backend.Service.Common.Views;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Configurations.Jwt
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthenticationConfigurations(this IServiceCollection services)
        {
            services.AddScoped<JwtProvider>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();
            services.AddScoped<UserState>();
            return services;
        }
    }
}
