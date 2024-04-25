using FluentValidation;
using Backend.Service.Data.Models.Order;
using System;

namespace Backend.Service.Features.GetProfiles
{ 
    public record GetProfilesRequest(string FirstName,string LastName,int Age,int PageIndex = 1,int PageSize = 50);
    public class GetProfilesRequestValidator : AbstractValidator<GetProfilesRequest>
    {
        public GetProfilesRequestValidator()
        {
            RuleFor(request => request.Age).NotEqual(0);
        }
    }
}
