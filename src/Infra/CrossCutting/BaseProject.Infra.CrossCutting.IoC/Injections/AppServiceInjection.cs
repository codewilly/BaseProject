using BaseProject.Application.Interfaces;
using BaseProject.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infra.CrossCutting.IoC.Injections
{
    public class AppServiceInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<IExampleAppService, ExampleAppService>();
        }
    }
}
