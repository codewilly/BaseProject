using BaseProject.Domain.Bases;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using System.Net;

namespace BaseProject.Domain.Services
{
    public class ExampleService : BaseService, IExampleService
    {
        public string Get(bool throwEx)
        {
            if (throwEx)
                throw new ApiException("Um erro esperado ocorreu.", HttpStatusCode.NotFound);

            return "Domain Service OK";
        }
    }
}
