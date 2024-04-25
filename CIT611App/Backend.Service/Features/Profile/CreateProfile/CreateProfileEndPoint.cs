using Backend.Service.Common.Views;
using Backend.Service.Configurations.Jwt;
using Backend.Service.Configurations.Localizations;
using Backend.Service.Features.Common;
using Backend.Service.Features.CreateProfile.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Service.Features.Profile.CreateProfile
{
    public class CreateProfileEndPoint : EndpointBase<CreateProfileRequest, CreateProfileResult>
    {

        public CreateProfileEndPoint(EndpointCommonDependencyCollection<CreateProfileRequest> dependencyCollection) : base(dependencyCollection)
        {
            _jsonStringLocalizer.TargetPath = "Features/Profile/CreateProfile";
        }



        [HttpPost("Profile/POST")]
        [JWTAuthorizationAttribute("Admin")]
        [ApiExplorerSettings(GroupName = "Profile")]

        public override async Task<ActionResult<Result<CreateProfileResult, Error>>> Handle(CreateProfileRequest request)
        {
            var result = await ValidateRequestAsync(request);
            if (result != null)
                return result;


            var createTripOrchestrator = _mapper.Map<CreateProfileOrchestrator>(request);
            result = await _mediator.Send(createTripOrchestrator);


            return result.Match(
                value => { value.Message = _jsonStringLocalizer["ProfileCreated"].ToString(); return result; },
                error => { error.Description = _jsonStringLocalizer[error.Code].ToString(); return result; }
                );
        }

    }
}
