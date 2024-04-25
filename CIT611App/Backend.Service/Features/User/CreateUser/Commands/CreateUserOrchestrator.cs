using MediatR;
using Backend.Service.Common.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Features.User.CreateUser;
using Backend.Service.Features.Authentication.Login.Queries;
using Backend.Service.Data.Models.User;

namespace Backend.Service.Features.CreateUser.Commands
{
    public record CreateUserOrchestrator( string Name,  string UserName ,
     string Password ,
     
     ApplicationRoleOption Role ) : IRequest<Result<CreateUserResult,Error>>;
    public class CreateUserOrchestratorHandler : IRequestHandler<CreateUserOrchestrator, Result<CreateUserResult, Error>>
    {
        private readonly IMediator _mediator;    
        public CreateUserOrchestratorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Result<CreateUserResult, Error>> Handle(CreateUserOrchestrator request, CancellationToken cancellationToken)
        {

            var user = new UserToCreate()
            {
                Name = request.Name,
                UserName = await _mediator.Send(new GetEncryptedStringQuery(request.UserName)),
                Password = await _mediator.Send(new GetEncryptedStringQuery(request.Password)),
                Role = request.Role
            };
           var userID = await _mediator.Send(new CreateUserCommand(user));
            //await _mediator.Send(new UpdateRiderToAvailableCommand(request.RiderId));
            //await _mediator.Send(new UpdateTripToCanceledCommand(request.TripId));
            var result = new CreateUserResult() { Message = "Created", ID = userID };
            return result;
        }
    }
}
