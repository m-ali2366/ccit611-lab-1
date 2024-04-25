using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Backend.Service.Data;

using Backend.Service.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Data.Models.User;

namespace Backend.Service.Features.Authentication.Login.Queries
{
    public class GetLogingUserQueryResult
    {
        public string UserID { get; set; }
        public ApplicationRoleOption Role { get; set; }
          
    }
    public record GetLogingUserQuery(string UserName, string  Password) : IRequest<GetLogingUserQueryResult>;
    public class GetLogingUserQueryHandler : IRequestHandler<GetLogingUserQuery, GetLogingUserQueryResult>
    {
        private readonly Repository<Models.User> _repository;
        public GetLogingUserQueryHandler(Repository<Models.User> repository)
        {
            _repository = repository;
        }
        public async Task<GetLogingUserQueryResult> Handle(GetLogingUserQuery request, CancellationToken cancellationToken)
        {

            return
            await _repository.Get(e => e.UserName == request.UserName && e.Password == request.Password)
                .ProjectToType<GetLogingUserQueryResult>()
                .FirstOrDefaultAsync();
        }
        public class GetLogingUserQueryResultMappingConfig : IRegister
        {
            public void Register(TypeAdapterConfig config)
            {
                config.NewConfig<Models.User, GetLogingUserQueryResult>()
                    .Map(dest=>dest.UserID, src=> src.ID);
            }
        }
    }

}
