using BaseProject.Domain.Bases;
using BaseProject.Domain.Interfaces;

namespace BaseProject.Domain.Services
{
    public class ExampleService : BaseService, IExampleService
    {
        public string Get()
        {
            return "Mensagem da domain recuperada com sucesso!";
        }
    }
}
