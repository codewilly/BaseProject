using BaseProject.Domain.Core.Interfaces;
using BaseProject.Domain.Core.Models;
using System.Net;

namespace BaseProject.Domain.Core.Bases
{
    public abstract class BaseResult
    {
        protected IResult Success(HttpStatusCode? statusCode = null)
        {
            return new Result(statusCode);
        }

        protected IResult<T> Success<T>(T data, HttpStatusCode? statusCode = null)
        {
            return new Result<T>(data, statusCode);
        }
    }
}
