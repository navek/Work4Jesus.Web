using System;
using System.Collections.Generic;
using System.ComponentModel;
using DomainCrudCommon.ValueRegisters.Interfaces;

namespace DomainCrudCommon.ValueRegisters
{
   public class ValueRegister : IValueRegister
    {

       private INotifyPropertyChanged _notify;
       internal Dictionary<string, IValueRegisterExecuter> _dictionary;
       public ValueRegister(INotifyPropertyChanged notify)
       {
            _dictionary = new Dictionary<string, IValueRegisterExecuter>();
           _notify = notify;
           _notify.PropertyChanged += _notify_PropertyChanged;
       }

        private void _notify_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!_dictionary.ContainsKey(e.PropertyName))
                return;
            _dictionary[e.PropertyName].LoadSerializedValueObject();
        }

       public void Register<T>(string propertyName, Action<string> updateAction ,
           Func<string> rawData, Action<T> loadAction,
           Func<T> getPropertyOfTheObjectFunction) where T:new ()
       {
            
           var info = new ValueRegisterExecuter<T>(updateAction,loadAction, getPropertyOfTheObjectFunction, rawData);
            _dictionary.Add(propertyName, info);
       }

       public void RegisterReflect<T>(string propertyName, Action<T> loadAction, Func<T> getPropertyOfTheObjectFunction) where T : new()
       {
            var info = new FastValueRegisterExecuter<T>(_notify,
                propertyName, loadAction,
                getPropertyOfTheObjectFunction);
            _dictionary.Add(propertyName, info);
        }

       public void Save()
       {
           foreach (var valueRegisterExecuter in _dictionary)
           { 
               valueRegisterExecuter.Value.SaveValueObjectOnRawData();
           }
       }
    }
}
