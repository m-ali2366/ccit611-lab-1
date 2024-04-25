using Hangfire.Annotations;
using Hangfire.Dashboard;
using Backend.Service.Configurations.Jwt;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Backend.Service.Configurations.Hangfire
{
    public class HangfireDashboardAuthorization : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            if (!string.IsNullOrEmpty(httpContext.Request.Path)) return true;
            string token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.LastOrDefault();
            if (string.IsNullOrEmpty(token))
                return false;
            var jwtProvider = httpContext.RequestServices.GetRequiredService<JwtProvider>();
            var userClaims = jwtProvider.ValidateTokenAsync(token).GetAwaiter().GetResult();
            return (userClaims is not null);
        }
    }
}
