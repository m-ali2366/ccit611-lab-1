using MediatR;
using Backend.Service.Common.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Features.Profile.DeleteProfile;
using Backend.Service.Features.Authentication.Login.Queries;
using Backend.Service.Features.Profile.Commands;

namespace Backend.Service.Features.DeleteProfile.Commands
{
    public record DeleteProfileOrchestrator(string ID ) : IRequest<Result<DeleteProfileResult,Error>>;
    public class DeleteProfileOrchestratorHandler : IRequestHandler<DeleteProfileOrchestrator, Result<DeleteProfileResult, Error>>
    {
        private readonly IMediator _mediator;    
        public DeleteProfileOrchestratorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Result<DeleteProfileResult, Error>> Handle(DeleteProfileOrchestrator request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteProfileCommand(request.ID));
            var result = new DeleteProfileResult() { Message = "Deleted", ID = request.ID };
            return result;
        }
    }
}
