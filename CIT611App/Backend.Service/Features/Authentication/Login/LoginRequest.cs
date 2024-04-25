using FluentValidation;
using Mapster;
using Backend.Service.Features.Authentication.Login.Commands;

namespace Backend.Service.Features.Authentication.Login
{
    public record LoginRequest(string UserName, string Password);
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(request => request.UserName).NotEmpty().WithErrorCode("UserNameEmpty");
            RuleFor(request => request.UserName).MinimumLength(6).WithErrorCode("UserNameLessThan6Chars");
            RuleFor(request => request.Password).NotEmpty().WithErrorCode("PasswordEmpty");
            RuleFor(request => request.Password).MinimumLength(6).WithErrorCode("PasswordLessThan6Chars");
        }
    }
    public class LoginRequestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginOrchestrator>()
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Password, src => src.Password);
        }
    }
}
