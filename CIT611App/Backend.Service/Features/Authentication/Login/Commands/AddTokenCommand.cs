using MediatR;
using Backend.Service.Data;
using Backend.Service.Models;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;

namespace Backend.Service.Features.Authentication.Login.Commands
{
    public record AddTokenCommand(TokenCreateRequest token) : IRequest;
    public class AddTokenCommandHandler : IRequestHandler<AddTokenCommand>
    {
        private readonly Repository<Models.Token> repository;
        private readonly IMapper _mapper;
        public AddTokenCommandHandler(Repository<Models.Token> _repository , IMapper mapper)
        {
            repository = _repository;
            _mapper = mapper;
        }
        public Task Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            repository.Add(_mapper.Map<Models.Token>(request.token));
            return Task.CompletedTask;
        }
    }
}
