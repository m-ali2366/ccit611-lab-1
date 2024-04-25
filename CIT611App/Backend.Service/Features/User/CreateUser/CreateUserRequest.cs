using Backend.Service.Data.Models.User;
using Mapster;
using Backend.Service.Models;
using FluentValidation;
using Backend.Service.Features.CreateUser.Commands;

namespace Backend.Service.Features.User.CreateUser
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public ApplicationRoleOption Role { get; set; }

    }
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(request => request.UserName).NotEmpty().MaximumLength(50).MinimumLength(5);
            RuleFor(request => request.Password).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
    public class CreateUserRequestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig< CreateUserRequest, Models.User>();

            config.NewConfig<CreateUserRequest, CreateUserOrchestrator>();
                   
            
        }
    }
}
