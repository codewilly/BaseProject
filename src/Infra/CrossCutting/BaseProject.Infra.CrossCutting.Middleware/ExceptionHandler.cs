using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using BaseProject.Infra.CrossCutting.CustomExceptions.Responses;
using BaseProject.Infra.CrossCutting.ExtensionHelper;
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
            catch (InvalidResultException ex)
            {
                await HandleValidationException(context, ex);
            }
            catch (ApiException ex)
            {
                await HandleException(context, ex, ex.StatusCode);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            ConfigureContextResponse(context, statusCode);

            ExceptionResponse response = new(exception);

            Console.WriteLine("Erro: " + exception.Message);

            await context.Response.WriteAsync(response.ToJson());
        }

        private async Task HandleValidationException(HttpContext context, InvalidResultException exception)
        {
            ConfigureContextResponse(context, HttpStatusCode.BadRequest);

            InvalidResponse response = new(exception);

            Console.WriteLine("Ocorreram falhas de validação: " + exception.Message);

            await context.Response.WriteAsync(response.ToJson());
        }

        private void ConfigureContextResponse(HttpContext context, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
        }
    }
}
