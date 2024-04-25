using Mapster;
using Backend.Service.Models;
using FluentValidation;
using Backend.Service.Features.CreateProfile.Commands;

namespace Backend.Service.Features.Profile.CreateProfile
{
    public class CreateProfileRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }
    public class CreateProfileRequestValidator : AbstractValidator<CreateProfileRequest>
    {
        public CreateProfileRequestValidator()
        {
            RuleFor(request => request.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(request => request.LastName).NotEmpty().MaximumLength(100);
            RuleFor(request => request.Age).NotEqual(0);
        }
    }
    public class CreateProfileRequestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig< CreateProfileRequest, Models.Profile>();

            config.NewConfig<CreateProfileRequest, CreateProfileOrchestrator>();
                   
            
        }
    }
}
