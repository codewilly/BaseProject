using BaseProject.API.Bases;
using BaseProject.Application.Interfaces;
using BaseProject.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPut]
        public IActionResult Create()
        {
            IResult result =
                _appService.Create();

            return Result(result);
        }

        /// <summary>
        /// Retorna uma mensagem de teste
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(bool throwException, bool throwNotification)
        {
            IResult<string> result =
                _appService.Get(throwException, throwNotification);

            return Result(result);
        }
    }
}
