namespace DomainCrudCommon.Interfaces.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }
        bool Valid(TEntity entity);
        string GetErrorMessage(string languageKey);
    }
}