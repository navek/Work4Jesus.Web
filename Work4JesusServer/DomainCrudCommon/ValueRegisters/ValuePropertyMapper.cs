using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DomainCrudCommon.ValueRegisters
{
    public class ValuePropertyMapper
    {
        private readonly Object _entity;
        private Dictionary<string, PropertyInfo> _dicProperty;
        public ValuePropertyMapper(Object entity, string propertiesMatch )
        {
            _dicProperty = new Dictionary<string, PropertyInfo>();
            _entity = entity;
            var desiredProperties =_entity.GetType().GetProperties(BindingFlags.Public).Where((prop) => prop.Name.ToLower().Contains(propertiesMatch.ToLower())).ToList();
            foreach (var desiredProperty in desiredProperties)
            {
                _dicProperty.Add(desiredProperty.Name, desiredProperty);
            }
        }

        /// <summary>
        /// It's will onl
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void SetPropertyValue(string propertyName, string value)
        {
            if(!_dicProperty.ContainsKey(propertyName))
                return;
            _dicProperty[propertyName].SetValue(_entity, value);
        }
    }
}
