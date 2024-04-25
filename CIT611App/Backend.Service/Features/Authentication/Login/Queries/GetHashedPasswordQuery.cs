using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Service.Data;

using Backend.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System;
using Backend.Service.Features.Common;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Service.Features.Authentication.Login.Queries
{
   
    public record GetHashedPasswordQuery(string password , string salt) : IRequest<string>;
    public class GetHashedPasswordQueryHandler : IRequestHandler<GetHashedPasswordQuery, string>
    {
        public GetHashedPasswordQueryHandler()
        {
        }
        public async Task<string> Handle(GetHashedPasswordQuery request, CancellationToken cancellationToken)
        {
            var salt = request.salt;
            if (string.IsNullOrEmpty(salt))
                salt = Constatns.Salt;
            string key = string.Join(":", new string[] { request.password.Trim(), salt });
            using (HMAC hmac = HMACSHA256.Create(SecurityAlgorithms.HmacSha256))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(Constatns.Salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Convert.ToBase64String(hmac.Hash);
            }
        }
      
    }

}
