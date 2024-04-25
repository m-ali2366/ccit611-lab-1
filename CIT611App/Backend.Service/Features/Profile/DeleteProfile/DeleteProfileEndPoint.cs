using Backend.Service.Common.Views;
using Backend.Service.Configurations.Jwt;
using Backend.Service.Configurations.Localizations;
using Backend.Service.Features.Common;
using Backend.Service.Features.DeleteProfile.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Service.Features.Profile.DeleteProfile
{
    public class DeleteProfileEndPoint : EndpointBase<DeleteProfileRequest, DeleteProfileResult>
    {

        public DeleteProfileEndPoint(EndpointCommonDependencyCollection<DeleteProfileRequest> dependencyCollection) : base(dependencyCollection)
        {
            _jsonStringLocalizer.TargetPath = "Features/Profile/DeleteProfile";
        }



        [HttpPost("Profile/Delete")]
        [JWTAuthorizationAttribute("Admin")]
        [ApiExplorerSettings(GroupName = "Profile")]

        public override async Task<ActionResult<Result<DeleteProfileResult, Error>>> Handle(DeleteProfileRequest request)
        {
            var result = await ValidateRequestAsync(request);
            if (result != null)
                return result;


            //var DeleteTripOrchestrator = _mapper.Map<DeleteProfileOrchestrator>(request);
            result = await _mediator.Send(new DeleteProfileOrchestrator(request.ID));


            return result.Match(
                value => { value.Message = _jsonStringLocalizer["ProfileDeleted"].ToString(); return result; },
                error => { error.Description = _jsonStringLocalizer[error.Code].ToString(); return result; }
                );
        }

    }
}
