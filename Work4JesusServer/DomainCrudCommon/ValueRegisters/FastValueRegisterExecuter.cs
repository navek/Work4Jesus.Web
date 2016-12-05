using System;
using System.Collections;
using Commons.Utils;
using DomainCrudCommon.ValueRegisters.Interfaces;
using Fasterflect;
using Newtonsoft.Json;

namespace DomainCrudCommon.ValueRegisters
{
    public class FastValueRegisterExecuter<T> : IValueRegisterExecuter where T : new()
    {
        private readonly Func<T> _getPropertyOfTheObjectFunction;
        private readonly Action<T> _loadAction;
        private readonly object _owner;
        private readonly MemberGetter _propertyGetter;
        private readonly MemberSetter _propertySetter;
        private bool _isLocked;
        private object _oldPropertie;
        public string PropertyName { get; private set; }

        public FastValueRegisterExecuter(object owner, string propertyName, Action<T> loadAction,
            Func<T> getPropertyOfTheObjectFunction)
        {
            PropertyName = propertyName;
            _owner = owner;
            var type = owner.GetType();
            _propertyGetter = type.DelegateForGetPropertyValue(propertyName);
            _propertySetter = type.DelegateForSetPropertyValue(propertyName);
            _loadAction = loadAction;
            _getPropertyOfTheObjectFunction = getPropertyOfTheObjectFunction;
        }


        public void SaveValueObjectOnRawData()
        {
            if (_isLocked)
                return;
            var currentPropertie = _getPropertyOfTheObjectFunction.Invoke();

            if (currentPropertie.OwnEqual(_oldPropertie))
                return;
            _isLocked = true;
            if (currentPropertie != null)
            {
                _propertySetter.Invoke(_owner, JsonConvert.SerializeObject(currentPropertie));
            }
            else
            {
                _propertySetter.Invoke(_owner, null);
            }
            var currentList = currentPropertie as IList;
            if (currentList == null)
                _oldPropertie = currentPropertie;
            else
            {
                _oldPropertie = currentList.CloneO();
            }
            _isLocked = false;
        }

        public void LoadSerializedValueObject()
        {
            _isLocked = true;
            var value = _propertyGetter?.Invoke(_owner) as string;
            if (value != null)
            {
                var l = JsonConvert.DeserializeObject<T>(value);
                if (l == null)
                    l = new T();
                _loadAction.Invoke(l);
            }
            _isLocked = false;
        }
    }
}