using BaseProject.Application.Bases;
using BaseProject.Application.Interfaces;
using BaseProject.Domain.CommandHandlers.Examples;
using BaseProject.Domain.Core.Interfaces;
using BaseProject.Domain.Interfaces;
using MediatR;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Application.Services
{
    public class ExampleAppService : BaseAppService, IExampleAppService
    {
        private readonly IExampleService _service;
        private readonly IMediator _mediator;

        public ExampleAppService(IExampleService service,
                                 IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        public async Task<IResult<Guid>> Create()
        {
            Guid id = await _mediator.Send(new CreateExampleCommand());

            return Success(id, HttpStatusCode.Created);
        }

        public IResult<string> Get(bool throwEx)
        {
            string message = _service.Get(throwEx);

            return Success(message);
        }
    }
}
