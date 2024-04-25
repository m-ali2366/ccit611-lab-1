using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Backend.Service.Common.Views;
using Backend.Service.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Service.Configurations.Jwt
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false)]
    public class JWTAuthorizationAttribute :Attribute,  IAsyncAuthorizationFilter
    {
        private readonly string[] _claims;
        public JWTAuthorizationAttribute(params string[] claims)
        {
            _claims = claims;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            bool isAuthorized = false;
            string token = context.HttpContext.Request.Headers["Token"].FirstOrDefault()?.Split(" ")?.LastOrDefault();
            if (!string.IsNullOrEmpty(token))
            {
                var jwtProvider = context.HttpContext.RequestServices.GetRequiredService<JwtProvider>();
                var userClaims = await jwtProvider.ValidateTokenAsync(token);
                if (userClaims is not null)
                {
                    var userState = context.HttpContext.RequestServices.GetRequiredService<UserState>();
                    userState.Claims = userClaims;
                    isAuthorized = _claims.Intersect(userClaims.Select(i => i.Value.ToString())).Any();
                }
            }
            if (isAuthorized == false)
            {
                Result<object, Error> result = new Error("501", "Un Authorized");
                context.Result = new JsonResult(result);
            }
        }
    }
}
