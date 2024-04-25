using Backend.Service.Common.Views;
using Backend.Service.Configurations.Jwt;
using Backend.Service.Data.Models.Order;
using Backend.Service.Features.Common;
using Backend.Service.Features.GetProfiles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Service.Features.GetProfiles
{
    public class GetProfilesIndexEndpoint : ControllerBase //: EndpointBase<GetProfilesRequest,PagingViewModel<GetProfilesResult>>
    {
        private readonly IMediator _mediator;

        public GetProfilesIndexEndpoint(IMediator mediator) //: base(dependencyCollection)
        {
            _mediator = mediator;
        }
        [HttpGet("Profile/Get")]
                        [ApiExplorerSettings(GroupName="Profile")]

        public async Task<Response<PagingViewModel<GetProfilesResult>>> Get(string firstName,string lastName,int age, int pageIndex = 1, int pageSize = 50)
        {
            //var result = await ValidateRequestAsync(request);
            //if (result != null)
            //    return result;

            var request = new GetProfilesRequest(firstName,lastName,age, pageIndex, pageSize);
            var Profiles = await _mediator.Send(new GetProfilesQuery(request));

            return new Response<PagingViewModel<GetProfilesResult>>(Profiles.Value);
                                
        }

    }
}
