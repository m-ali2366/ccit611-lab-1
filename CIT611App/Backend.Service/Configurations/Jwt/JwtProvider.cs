using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Backend.Service.Models;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Backend.Service.Configurations.Jwt
{
    public class JwtProvider
    {
        private readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateJwtToken(Dictionary<string, string> userClaims)
        {
            List<Claim> claims = new();
            foreach (var additional in userClaims)
                claims.Add(new(additional.Key, additional.Value));
            var signingCredentails =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                System.DateTime.Now.AddDays(_options.TokenLifetimeInDays),
                signingCredentails
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<Dictionary<string,object>> ValidateTokenAsync(string token) 
        {

            if (string.IsNullOrEmpty(token)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var tokenValidationResult = await tokenHandler.ValidateTokenAsync(token, BuildTokenValidationParameters());
            if (!tokenValidationResult.IsValid) return null;

            return tokenValidationResult.Claims.ToDictionary();
        }
        private TokenValidationParameters BuildTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.Audience
            };
        }
    }
}
