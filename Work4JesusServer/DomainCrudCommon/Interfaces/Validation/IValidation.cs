using DomainCrudCommon.Validation;

namespace DomainCrudCommon.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {

        ValidationResult Valid(TEntity entity, string language);
    }
}