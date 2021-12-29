using BaseProject.Infra.CrossCutting.IoC.Injections;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            AppServiceInjection.Inject(services);
            ServiceInjection.Inject(services);
            MiddlewareInjection.Inject(services);
        }
    }
}
