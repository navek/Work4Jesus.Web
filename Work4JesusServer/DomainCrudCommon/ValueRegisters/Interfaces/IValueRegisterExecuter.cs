using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DomainCrudCommon.ValueRegisters.Interfaces
{

    internal interface IValueRegisterExecuter
    {
        void SaveValueObjectOnRawData();
        void LoadSerializedValueObject();
    }
    internal class ValueRegisterExecuter<T> : IValueRegisterExecuter where T : new()
    {
        public Action<string> SaveAction;
        private readonly Func<T> _getPropertieReferenceOfTheObjectFunc;
        private readonly Action<T> _loadAction;
        private readonly Func<string> _rawDataFunc;
        public T OldPropertie;
        private bool _isLocked;

        public ValueRegisterExecuter(Action<string> saveAction, Action<T> loadAction,

            Func<T> getPropertyOfTheObjectFunction, Func<string>  rawDataFunc)
        {
            SaveAction = saveAction;
            _loadAction = loadAction;
            _rawDataFunc = rawDataFunc;
            _getPropertieReferenceOfTheObjectFunc = getPropertyOfTheObjectFunction;
        }

        public class SisoJsonDefaultContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(
                MemberInfo member,
                MemberSerialization memberSerialization)
            {
                //TODO: Maybe cache
                var prop = base.CreateProperty(member, memberSerialization);

                if (!prop.Writable)
                {
                    var property = member as PropertyInfo;
                    if (property != null)
                    {
                        var hasPrivateSetter = property.GetSetMethod(true) != null;
                        prop.Writable = hasPrivateSetter;
                    }
                }

                return prop;
            }
        }
        public void LoadSerializedValueObject()
        {
            _isLocked = true;
            var value = _rawDataFunc?.Invoke();
            if (value != null)
            {
                _loadAction.Invoke(JsonConvert.DeserializeObject<T>(value));
            }
            _isLocked = false;
        }


        public void SaveValueObjectOnRawData()
        {
            if(_isLocked)
                return;
            var currentPropertie = _getPropertieReferenceOfTheObjectFunc.Invoke();

            if (Equals(currentPropertie, OldPropertie))
                return;
            _isLocked = true;
            if (currentPropertie != null)
                SaveAction.Invoke(JsonConvert.SerializeObject(currentPropertie));
            else
            {
                SaveAction.Invoke(null);
            }
            OldPropertie = currentPropertie;
            _isLocked = false;

        }

    }

}
