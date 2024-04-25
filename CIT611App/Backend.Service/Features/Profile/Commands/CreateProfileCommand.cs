using MediatR;
using Backend.Service.Common.Views;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Data;
using MapsterMapper;
using Mapster;

namespace Backend.Service.Features.Profile.Commands
{
    public record CreateProfileCommand(string FirstName,string LastName,int Age ) : IRequest<string>;
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, string>
    {
        private readonly Repository<Models.Profile> _repository;    
        private readonly IMapper _mapper;    
        public CreateProfileCommandHandler(Repository<Models.Profile> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public  async Task<string> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var Profile = _mapper.Map<Models.Profile>(request);
            
            var createdProfile = await _repository.AddAsync(Profile);
            return createdProfile.ID;
        }
    }
  public class ProfileToCreateMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateProfileCommand, Models.Profile>();
        }
    }
}
