using BaseProject.Infra.CrossCutting.ExtensionHelper;
using BaseProject.Infra.CrossCutting.Middleware.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Infra.CrossCutting.Middleware
{
    public class ExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            ExceptionResponse response = new("Erro inesperado.", exception);

            Console.WriteLine("Erro: " + exception.Message);

            await context.Response.WriteAsync(response.ToJson());
        }
    }
}
