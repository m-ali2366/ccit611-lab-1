using MediatR;
using Backend.Service.Data;
using Backend.Service.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.Features.Authentication.Login.Commands
{
    public record LoginCommand(string userID ) : IRequest;
    public class LoginCommandHandler : IRequestHandler<LoginCommand>
    {
        private readonly Repository<Models.User> repository;
        public LoginCommandHandler(Repository<Models.User> _repository)
        {
            repository = _repository;
        }
        public Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            
            repository.SaveIncluded(new Models.User { LastLogin =System.DateTime.Now, ID = request.userID },
            "LastLogin");
            return Task.CompletedTask;
        }
    }
}
