using MediatR;
using Backend.Service.Common.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Features.Profile.CreateProfile;
using Backend.Service.Features.Authentication.Login.Queries;
using Backend.Service.Features.Profile.Commands;

namespace Backend.Service.Features.CreateProfile.Commands
{
    public record CreateProfileOrchestrator(string FirstName,string LastName,int Age ) : IRequest<Result<CreateProfileResult,Error>>;
    public class CreateProfileOrchestratorHandler : IRequestHandler<CreateProfileOrchestrator, Result<CreateProfileResult, Error>>
    {
        private readonly IMediator _mediator;    
        public CreateProfileOrchestratorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Result<CreateProfileResult, Error>> Handle(CreateProfileOrchestrator request, CancellationToken cancellationToken)
        {
            var profileID = await _mediator.Send(new CreateProfileCommand(request.FirstName,request.LastName,request.Age));
            var result = new CreateProfileResult() { Message = "Created", ID = profileID };
            return result;
        }
    }
}
