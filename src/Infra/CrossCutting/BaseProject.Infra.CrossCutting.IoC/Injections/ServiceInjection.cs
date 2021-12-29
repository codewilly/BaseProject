using BaseProject.Domain.Interfaces;
using BaseProject.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infra.CrossCutting.IoC.Injections
{
    public class ServiceInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IExampleService, ExampleService>();
        }
    }
}
