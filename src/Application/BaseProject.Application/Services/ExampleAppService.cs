using BaseProject.Application.Bases;
using BaseProject.Application.Interfaces;
using BaseProject.Domain.Core.Interfaces;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using System;
using System.Net;

namespace BaseProject.Application.Services
{
    public class ExampleAppService : BaseAppService, IExampleAppService
    {
        private readonly IExampleService _service;

        public ExampleAppService(IExampleService service)
        {
            _service = service;
        }

        public IResult Create()
        {
            bool isCreated = _service.Create();

            if (!isCreated)
                throw new ApiException("Falha ao criar.");

            return Success(statusCode: HttpStatusCode.Created);
        }

        public IResult<string> Get(bool throwEx, bool throwInvalid)
        {
            string message = _service.Get(throwEx, throwInvalid);

            return Success(message);
        }
    }
}
