using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Backend.Service.Configurations.Hangfire
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseHangfire(this IApplicationBuilder app, IConfiguration configuration)
        {
            bool isEnabled = configuration.GetValue<bool>("Hangfire:Enabled");
            if (!isEnabled)
                return;
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization= new[] { new HangfireDashboardAuthorization()}, 
                IsReadOnlyFunc = (context)=> true, 
            });
        }
    }
}
