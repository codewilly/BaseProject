using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using BaseProject.Infra.CrossCutting.CustomExceptions.Responses;
using BaseProject.Infra.CrossCutting.ExtensionHelper;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseProject.Infra.CrossCutting.Middleware
{
    public class ExceptionHandler : IMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExceptionHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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
            string traceId = GetTraceIdentifier();

            ConfigureContextResponse(context, statusCode);

            ExceptionResponse response = new(exception, traceId);

            Log.Error(exception, "{traceId} - Erro:", traceId);

            await context.Response.WriteAsync(response.ToJson());
        }

        private async Task HandleValidationException(HttpContext context, InvalidResultException exception)
        {
            string traceId = GetTraceIdentifier();

            ConfigureContextResponse(context, HttpStatusCode.BadRequest);

            InvalidResponse response = new(exception, traceId);

            Log.Warning(exception, "{traceId} - Ocorreram falhas de validação:", traceId);

            await context.Response.WriteAsync(response.ToJson());
        }

        private void ConfigureContextResponse(HttpContext context, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
        }

        private string GetTraceIdentifier()
        {
            return _httpContextAccessor.HttpContext.TraceIdentifier;
        }
    }
}
