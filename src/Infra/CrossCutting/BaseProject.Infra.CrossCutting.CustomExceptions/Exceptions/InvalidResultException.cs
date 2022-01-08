using FluentValidation.Results;
using System;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions
{
    public class InvalidResultException : Exception
    {
        public InvalidResultException(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; set; }
    }
}
