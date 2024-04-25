using FluentValidation;
using MapsterMapper;
using MediatR;
using Backend.Service.Data;
using Backend.Service.Configurations.Localizations;

namespace Backend.Service.Features.Common
{
    public class EndpointCommonDependencyCollection<T>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<T> _validator;
        private readonly IMapper _mapper;
        private readonly JsonStringLocalizer _jsonStringLocalizer;

        public IMediator Mediator => _mediator;
        public IValidator<T> Validator => _validator;
        public IMapper Mapper => _mapper;
        public JsonStringLocalizer JsonStringLocalizer => _jsonStringLocalizer;

        public EndpointCommonDependencyCollection(IMediator mediator, IValidator<T> validator, JsonStringLocalizer jsonStringLocalizer, IMapper mapper)
        {
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
            _jsonStringLocalizer = jsonStringLocalizer;
        }

    }
}
