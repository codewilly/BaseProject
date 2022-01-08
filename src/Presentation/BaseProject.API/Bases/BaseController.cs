using BaseProject.API.ViewModels;
using BaseProject.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BaseProject.API.Bases
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult Result(IResult result)
        {
            ResultViewModel _result = new()
            {
                TraceId = Guid.NewGuid() // TODO: Implementar traceId real
            };

            return StatusCode((int)result.StatusCode, _result);
        }

        protected IActionResult Result<T>(IResult<T> result)
        {
            ResultViewModel<T> _result = new()
            {
                Data = result.Data,
                TraceId = Guid.NewGuid() // TODO: Implementar traceId real
            };

            return StatusCode((int)result.StatusCode, _result);
        }
    }
}
