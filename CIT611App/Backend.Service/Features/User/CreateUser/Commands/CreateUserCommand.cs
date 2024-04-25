using MediatR;
using Backend.Service.Common.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Features.User.CreateUser;
using Backend.Service.Data;
using MapsterMapper;

namespace Backend.Service.Features.CreateUser.Commands
{
    public record CreateUserCommand(UserToCreate createUserRequest ) : IRequest<string>;
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly Repository<Models.User> _repository;    
        private readonly IMapper _mapper;    
        public CreateUserCommandHandler(Repository<Models.User> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public  async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Models.User>(request.createUserRequest);
            
            var createdUser = await _repository.AddAsync(user);
            return createdUser.ID;
        }
    }
}
