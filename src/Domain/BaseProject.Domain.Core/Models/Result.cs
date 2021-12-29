using BaseProject.Domain.Core.Interfaces;
using System.Net;

namespace BaseProject.Domain.Core.Models
{
    public class Result : IResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpStatusCode GetStatusCode() => StatusCode;
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public T GetData() => Data;
    }
}
