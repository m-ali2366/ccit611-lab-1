using LinqKit;
using Backend.Service.Common.Views;
using Backend.Service.Configurations;
using Backend.Service.Data;
using Backend.Service.Models;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Service.Features.GetProfiles.Queries
{
    public record GetProfilesQuery(GetProfilesRequest request):IRequest<Result<PagingViewModel<GetProfilesResult>,Error>>;
    public class GetProfilesQueryHandler : IRequestHandler<GetProfilesQuery, Result<PagingViewModel<GetProfilesResult>, Error>>
    {
        private readonly Repository<Models.Profile> _repository;

        public GetProfilesQueryHandler(Repository<Models.Profile> repository)
        {
            _repository = repository;
        }

        public async Task<Result<PagingViewModel<GetProfilesResult>, Error>> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            ExpressionStarter<Models.Profile> predicate = PredicateBuilder(request);

            var profiles = _repository.Get().ProjectToType<GetProfilesResult>();
            return await PagingHelper.CreateAsync(profiles, request.request.PageIndex, request.request.PageSize);
        }

        private static ExpressionStarter<Models.Profile> PredicateBuilder(GetProfilesQuery request)
        {
            var predicate = LinqKit.PredicateBuilder.New<Models.Profile>();
        

            // if (!string.IsNullOrEmpty(request.request.FirstName))
            //     predicate.And(x => x.FirstName == request.request.FirstName);

            //             if (!string.IsNullOrEmpty(request.request.LastName))
            //     predicate.And(x => x.LastName == request.request.LastName);

            //              if (request.request.Age!=0)
            //     predicate.And(x => x.Age == request.request.Age);

           
            return predicate;
        }
    }
}
