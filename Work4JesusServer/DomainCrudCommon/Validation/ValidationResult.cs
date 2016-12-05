using System.Collections.Generic;
using System.Linq;

namespace DomainCrudCommon.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _erros;

        public string Message
        {
            get
            {
                var message = string.Empty;
                foreach (var validationError in Errors)
                {
                    message += validationError.Message + @"\n";
                }
                return message;
            }
        }

        public bool IsValid => !_erros.Any();
        public IEnumerable<ValidationError> Errors => _erros;

        public string Language { get; set; }
        public ValidationResult()
        {
            _erros = new List<ValidationError>();
        }

        public ValidationResult Add(string errorMessage)
        {
            _erros.Add(new ValidationError(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationError error)
        {
            _erros.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _erros.AddRange(result.Errors);

            return this;
        }

        public ValidationResult Remove(ValidationError error)
        {
            if (_erros.Contains(error))
                _erros.Remove(error);
            return this;
        }
    }
}