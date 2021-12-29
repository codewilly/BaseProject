using BaseProject.Infra.CrossCutting.Middleware;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infra.CrossCutting.IoC.Injections
{
    public class MiddlewareInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddTransient<ExceptionHandler>();
        }
    }
}
