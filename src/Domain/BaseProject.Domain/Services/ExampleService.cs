using BaseProject.Domain.Bases;
using BaseProject.Domain.Interfaces;
using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using FluentValidation.Results;
using System.Net;

namespace BaseProject.Domain.Services
{
    public class ExampleService : BaseService, IExampleService
    {
        public bool Create()
        {
            return true;
        }

        public string Get(bool throwEx, bool throwInvalid)
        {
            ValidationResult fakeValidation = new();

            fakeValidation.Errors.Add(new ValidationFailure(null, "Notificação Genérica"));
            fakeValidation.Errors.Add(new ValidationFailure("CPF", "CPF inválido"));

            if (throwInvalid)
                throw new InvalidResultException(fakeValidation);

            if (throwEx)
                throw new ApiException("Erro especial", HttpStatusCode.NotFound);

            return "Domain Service OK";
        }
    }
}
