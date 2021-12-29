using BaseProject.Application.Bases;
using BaseProject.Application.Interfaces;
using BaseProject.Domain.Core.Interfaces;
using BaseProject.Domain.Interfaces;

namespace BaseProject.Application.Services
{
    public class ExampleAppService : BaseAppService, IExampleAppService
    {
        private readonly IExampleService _service;

        public ExampleAppService(IExampleService service)
        {
            _service = service;
        }

        public IResult<string> Get()
        {
            string message = _service.Get();

            return Success(message);
        }
    }
}
