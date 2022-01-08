using System;
using System.Net;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, HttpStatusCode? statusCode = null) : base(message)
        {
            StatusCode = statusCode ?? HttpStatusCode.InternalServerError;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
