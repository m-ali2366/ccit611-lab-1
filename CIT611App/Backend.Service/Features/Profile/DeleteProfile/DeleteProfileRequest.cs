using Mapster;
using Backend.Service.Models;
using FluentValidation;
using Backend.Service.Features.DeleteProfile.Commands;

namespace Backend.Service.Features.Profile.DeleteProfile
{
    public class DeleteProfileRequest
    {
        public string ID { get; set; }
       

    }
    public class DeleteProfileRequestValidator : AbstractValidator<DeleteProfileRequest>
    {
        public DeleteProfileRequestValidator()
        {
            RuleFor(request => request.ID).NotNull().NotEmpty().MinimumLength(20).MaximumLength(100);
           
        }
    }
    public class DeleteProfileRequestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig< DeleteProfileRequest, Models.Profile>();

            config.NewConfig<DeleteProfileRequest, DeleteProfileOrchestrator>();
                   
            
        }
    }
}
