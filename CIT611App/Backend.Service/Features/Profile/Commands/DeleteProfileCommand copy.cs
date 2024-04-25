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
    public record DeleteProfileCommand(string ID ) : IRequest;
    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand>
    {
        private readonly Repository<Models.Profile> _repository;    
        private readonly IMapper _mapper;    
        public DeleteProfileCommandHandler(Repository<Models.Profile> repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public  async Task Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            var Profile = _mapper.Map<Models.Profile>(request);
            
            _repository.Delete(request.ID);
            //return request.ID;
        }
    }
  public class ProfileToDeleteMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<DeleteProfileCommand, Models.Profile>();
        }
    }
}
