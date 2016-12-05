using DomainCrudCommon.Interfaces;
using DomainCrudCommon.Interfaces.Validation;
//using Microsoft.Practices.ServiceLocation;

//using YokQuizz.InversionOfControl;

namespace DomainCrudCommon.Validation
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        private readonly string _messageKey;
        public ValidationRule(ISpecification<TEntity> specificationRule, string errorMessage, bool isMessageKey = true)
        {
            _specificationRule = specificationRule;
            if (isMessageKey)
            {
                _messageKey = errorMessage;
                ErrorMessage = errorMessage;
            }
            else
            ErrorMessage = errorMessage;
            
        }

        public string ErrorMessage { get; private set; }
        public bool Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }

        public string GetErrorMessage(string languageKey)
        {
            return languageKey;
            //  if (!ServiceLocator.IsLocationProviderSet)
            //      return ErrorMessage;
            //return  ServiceLocator.Current.GetInstance<ILanguageService>().Get(languageKey, _messageKey);
        }
    }
}
