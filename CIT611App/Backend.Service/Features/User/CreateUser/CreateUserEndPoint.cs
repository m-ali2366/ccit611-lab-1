using Backend.Service.Common.Views;
using Backend.Service.Configurations.Localizations;
using Backend.Service.Features.Common;
using Backend.Service.Features.CreateUser.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Service.Features.User.CreateUser
{
    public class CreateUserEndPoint : EndpointBase<CreateUserRequest, CreateUserResult>
    {

        public CreateUserEndPoint(EndpointCommonDependencyCollection<CreateUserRequest> dependencyCollection) : base(dependencyCollection)
        {
            _jsonStringLocalizer.TargetPath = "Features/User/CreateUser";
        }



        [HttpPost("User/Create")]
        [ApiExplorerSettings(GroupName="User")]
        public override async Task<ActionResult<Result<CreateUserResult, Error>>> Handle(CreateUserRequest request)
        {
            var result = await ValidateRequestAsync(request);
            if (result != null)
                return result;


            var createTripOrchestrator = _mapper.Map<CreateUserOrchestrator>(request);
            result = await _mediator.Send(createTripOrchestrator);


            return result.Match(
                value => { value.Message = _jsonStringLocalizer["UserCreated"].ToString(); return result; },
                error => { error.Description = _jsonStringLocalizer[error.Code].ToString(); return result; }
                );
        }
    
    }
}
