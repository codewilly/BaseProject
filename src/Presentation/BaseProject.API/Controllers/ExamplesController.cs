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

        [HttpGet]
        public IActionResult Get()
        {
            IResult<string> result =
                _appService.Get();

            return Result(result);
        }
    }
}
