using Microsoft.AspNetCore.Http;
using Serilog;
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

            Log.Information("{traceId} - [{method}]: {route}", traceId, method, route);

            Stopwatch stopwatch = Stopwatch.StartNew();

            await next(context);

            stopwatch.Stop();

            Log.Information("{traceId} - Finished with code {code} in {ms}ms", traceId, _httpContext.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        }
    }
}
