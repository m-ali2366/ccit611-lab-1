using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System;
using DotNetCore.CAP;

namespace Backend.Service.Data
{
    public class TransactionMiddleware : IMiddleware
    {
        private readonly EntitiesContext _entitiesContext;
        private readonly ICapPublisher _capPublisher;
        public TransactionMiddleware(EntitiesContext entitiesContext, ICapPublisher capPublisher)
        {
            _entitiesContext = entitiesContext;
            _capPublisher = capPublisher;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (IsTransactionRequired(context.Request.Method))
            {
                using (var transaction = _entitiesContext.Database.BeginTransaction(_capPublisher, false))
                {
                    try
                    {
                        await next(context);
                        await  _entitiesContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            else
            {
                await next(context);
            }
        }
        private static bool IsTransactionRequired(string method)
        {
            return method.ToUpper() == "POST" || method.ToUpper() == "PUT" || method.ToUpper() == "DELETE";
        }
    }
}
