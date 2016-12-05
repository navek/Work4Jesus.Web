using System;

namespace DomainCrudCommon.ValueRegisters.Interfaces
{
    public interface IValueRegister
    {
         void Register<T>(string propertyName, Action<string> updateAction, Func<string> rawData,Action<T> loadAction
            , Func<T> getPropertyOfTheObjectFunction) where T : new();

         void RegisterReflect<T>(string propertyName, Action<T> loadAction, Func<T> getPropertyOfTheObjectFunction) where T : new();
    }
}
