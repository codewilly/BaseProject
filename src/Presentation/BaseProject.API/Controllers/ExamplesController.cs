using BaseProject.API.Bases;
using BaseProject.Application.Interfaces;
using BaseProject.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BaseProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamplesController : BaseController
    {
        private readonly IExampleAppService _appService;

        public ExamplesController(IExampleAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Cria alguma coisa
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FakePayload payload)
        {
            IResult<Guid> result =
                await _appService.Create();

            return Result(result);
        }

        /// <summary>
        /// Retorna uma mensagem de teste
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(bool throwException)
        {
            IResult<string> result =
                _appService.Get(throwException);

            return Result(result);
        }
    }

    public class FakePayload
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public AddressPayload Address { get; set; }
    }

    public class AddressPayload
    {
        public string Street { get; set; }

        public int Number { get; set; }
    }
}
