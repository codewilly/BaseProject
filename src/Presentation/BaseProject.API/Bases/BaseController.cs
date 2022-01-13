using BaseProject.API.ViewModels;
using BaseProject.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BaseProject.API.Bases
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Result(IResult result)
        {
            ResultViewModel _result = new()
            {
                TraceId = HttpContext.TraceIdentifier
            };

            return StatusCode((int)result.StatusCode, _result);
        }

        protected IActionResult Result<T>(IResult<T> result)
        {
            ResultViewModel<T> _result = new()
            {
                Data = result.Data,
                TraceId = HttpContext.TraceIdentifier
            };

            return StatusCode((int)result.StatusCode, _result);
        }
    }
}
