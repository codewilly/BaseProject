using BaseProject.Application.Bases;
using BaseProject.Application.Interfaces;
using BaseProject.Domain.Core.Interfaces;
using BaseProject.Domain.Interfaces;
using System;

namespace BaseProject.Application.Services
{
    public class ExampleAppService : BaseAppService, IExampleAppService
    {
        private readonly IExampleService _service;

        public ExampleAppService(IExampleService service)
        {
            _service = service;
        }

        public IResult<string> Get(bool throwException)
        {
            if (throwException)
                throw new Exception("Erro de teste disparado com sucesso.");

            string message = _service.Get();

            return Success(message);
        }
    }
}
