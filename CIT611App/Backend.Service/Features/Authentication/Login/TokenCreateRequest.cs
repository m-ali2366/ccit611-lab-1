using FluentValidation;
using Mapster;
using Backend.Service.Features.Authentication.Login.Commands;
using System;

namespace Backend.Service.Features.Authentication.Login
{
    public record TokenCreateRequest(  string UserID ,
     string Code ,
     DateTime ExpirationDate );

    public class TokenCreateRequestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<TokenCreateRequest, Models.Token>();
        }
    }
}
