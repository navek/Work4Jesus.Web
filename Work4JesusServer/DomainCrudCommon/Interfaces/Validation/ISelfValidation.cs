using DomainCrudCommon.Validation;

namespace DomainCrudCommon.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}