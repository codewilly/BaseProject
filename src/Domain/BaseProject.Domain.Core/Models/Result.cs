using BaseProject.Domain.Core.Interfaces;
using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using FluentValidation.Results;
using System.Net;

namespace BaseProject.Domain.Core.Models
{
    public class Result : IResult
    {
        public Result(HttpStatusCode? statusCode = null)
        {
            StatusCode = statusCode ?? HttpStatusCode.OK;
        }

        public HttpStatusCode StatusCode { get; set; }

    }

    public class Result<T> : Result, IResult<T>
    {
        public Result(T data, HttpStatusCode? statusCode = null) : base(statusCode)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
