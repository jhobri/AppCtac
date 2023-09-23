using AutoMapper;
using MediatR;

namespace Back.Ctac.Application
{
    public class GenericApplication
    {
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public GenericApplication(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}