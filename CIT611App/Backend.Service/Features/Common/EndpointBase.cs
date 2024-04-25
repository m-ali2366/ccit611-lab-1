using Azure.Core;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Backend.Service.Common.Views;
using Backend.Service.Data;
using System.Linq;
using System.Threading.Tasks;
using Backend.Service.Configurations.Localizations;

namespace Backend.Service.Features.Common
{
    [ApiController]
    public abstract class EndpointBase<TRequest, TResult> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IValidator<TRequest> _validator;
        protected readonly IMapper _mapper;
        protected readonly JsonStringLocalizer _jsonStringLocalizer;
        
        public EndpointBase(EndpointCommonDependencyCollection<TRequest> dependencyCollection)
        {
            _mediator = dependencyCollection.Mediator;  
            _validator = dependencyCollection.Validator;
            _mapper = dependencyCollection.Mapper;
            _jsonStringLocalizer = dependencyCollection.JsonStringLocalizer;
        }

        protected virtual async Task<Result<TResult, Error>> ValidateRequestAsync(TRequest request)
        {
            Result<TResult, Error> result = null;
            var validationResults = await _validator.ValidateAsync(request);
            if (!validationResults.IsValid)
            {
                var validationErrors = string.Join(", ", validationResults.Errors.Select(e => _jsonStringLocalizer[e.ErrorCode].ToString()));
                result = new Error("ValidationSummary", validationErrors);
            }
            return result;
        }
        public abstract Task<ActionResult<Result<TResult, Error>>> Handle(TRequest TRequest);

    }
}
