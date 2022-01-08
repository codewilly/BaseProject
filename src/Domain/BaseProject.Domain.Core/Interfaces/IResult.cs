using FluentValidation.Results;
using System.Net;

namespace BaseProject.Domain.Core.Interfaces
{
    public interface IResult
    {
        public HttpStatusCode StatusCode { get; set; }
    }

    public interface IResult<T> : IResult
    {
        public T Data { get; set; }
    }    
}
