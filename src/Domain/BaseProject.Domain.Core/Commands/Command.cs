using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using FluentValidation.Results;
using MediatR;

namespace BaseProject.Domain.Core.Commands
{
    public abstract class Command<T> : IRequest<T>
    {
        public Command()
        {
            ValidationResult = new();
        }

        protected ValidationResult ValidationResult { get; set; }

        public virtual void Validate()
        {
            if (!ValidationResult.IsValid)
                throw new InvalidResultException(ValidationResult);
        }
    }
}
