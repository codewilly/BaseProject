using BaseProject.Infra.CrossCutting.CustomExceptions.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BaseProject.Infra.CrossCutting.CustomExceptions.Responses
{
    public class InvalidResponse : Response
    {
        public InvalidResponse(InvalidResultException validationException, string traceId) : base(traceId)
        {
            Fields =
                validationException.ValidationResult.Errors
                                   .Where(validation => !string.IsNullOrEmpty(validation.PropertyName))
                                   .Select(validation => new InvalidResponseField(validation.PropertyName, validation.ErrorMessage));

            Notifications =
                validationException.ValidationResult.Errors
                                   .Where(validation => string.IsNullOrEmpty(validation.PropertyName))
                                   .Select(validation => validation.ErrorMessage);
        }

        public IEnumerable<InvalidResponseField> Fields { get; set; }

        public IEnumerable<string> Notifications { get; set; }
    }
}
