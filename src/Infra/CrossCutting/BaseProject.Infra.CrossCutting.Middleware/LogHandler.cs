using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Infra.CrossCutting.Middleware
{
    public class LogHandler : IMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            HttpContext _httpContext = _httpContextAccessor.HttpContext;

            string traceId = _httpContext.TraceIdentifier;
            string method = _httpContext.Request.Method;
            string route = _httpContext.Request.Path + _httpContext.Request.QueryString.Value;

            // TODO: Caso contenha body, fazer o log da requisição excluindo dados sensíveis (como senhas)

            string requestLog = $"{traceId} - [{method}]: {route}";

            Console.WriteLine(requestLog);

            Stopwatch stopwatch = Stopwatch.StartNew();

            await next(context);

            stopwatch.Stop();

            string responseLog = $"{traceId} - Finished with code {_httpContext.Response.StatusCode} in {stopwatch.ElapsedMilliseconds}ms";

            Console.WriteLine(responseLog);
        }
    }
}
