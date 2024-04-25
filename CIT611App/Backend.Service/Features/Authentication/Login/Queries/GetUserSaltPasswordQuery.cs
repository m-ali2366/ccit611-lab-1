using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Service.Data;

using Backend.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.Features.Authentication.Login.Queries
{
    public class GetUserSaltPasswordQueryResult
    {
        public string SaltPassword { get; set; }
      
    }
    public record GetUserSaltPasswordQuery(string UserName) : IRequest<GetUserSaltPasswordQueryResult>;
    public class GetUserSaltPasswordQueryHandler : IRequestHandler<GetUserSaltPasswordQuery, GetUserSaltPasswordQueryResult>
    {
        private readonly Repository<Models.User> _repository;
        public GetUserSaltPasswordQueryHandler(Repository<Models.User> repository)
        {
            _repository = repository;
        }
        public async Task<GetUserSaltPasswordQueryResult> Handle(GetUserSaltPasswordQuery request, CancellationToken cancellationToken)
        {
            return
            await _repository.Get(e => e.UserName == request.UserName )
                .ProjectToType<GetUserSaltPasswordQueryResult>()
                .FirstOrDefaultAsync();
        }
        public class GetUserSaltPasswordQueryResultMappingConfig : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<Models.User, GetUserSaltPasswordQueryResult>();
            }
        }
    }

}
