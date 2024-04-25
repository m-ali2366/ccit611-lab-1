using Backend.Service.Common.Views;
using Backend.Service.Features.Authentication.Login.Commands;
using Backend.Service.Features.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Service.Features.Authentication.Login
{
    public class LoginEndpoint : EndpointBase<LoginRequest, LoginResult>
    {
        public LoginEndpoint(EndpointCommonDependencyCollection<LoginRequest> dependencyCollection) : base(dependencyCollection)
        {
            _jsonStringLocalizer.TargetPath = "Features/Authentication/Login";
        }


        [HttpPost("User/Login")]
        [ApiExplorerSettings(GroupName = "User")]

        public override async Task<ActionResult<Result<LoginResult, Error>>> Handle(LoginRequest request)
        {
            var result = await ValidateRequestAsync(request);
            if (result != null)
                return result;


            var loginOrchestrator = _mapper.Map<LoginOrchestrator>(request);
            result = await _mediator.Send(loginOrchestrator);


            return result.Match(
                value => { value.Message = _jsonStringLocalizer["LoggedIn"].ToString(); return result; },
                error => { error.Description = _jsonStringLocalizer[error.Code].ToString(); return result; }
                                );
        }

    }
}