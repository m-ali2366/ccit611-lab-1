using Microsoft.AspNetCore.Builder;

namespace Backend.Service.Configurations
{
    public static class IApplicationBuilderExtensions
    {
        public static void ConfigCORS(this IApplicationBuilder app)
        {
            app.UseCors("AllowAll");
        }
    }
}
