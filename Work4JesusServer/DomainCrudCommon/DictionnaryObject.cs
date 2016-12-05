using System.Collections.Generic;
using Newtonsoft.Json;

namespace DomainCrudCommon
{
    public class DictionnaryObject<Key, Value> 
    {
        private Dictionary<Key, Value> _dictionary;

        public DictionnaryObject()
        {
            _dictionary = new Dictionary<Key, Value>();
        }
        public DictionnaryObject(string value)
        {
            _dictionary = JsonConvert.DeserializeObject<Dictionary<Key, Value>>(value);
        }

       

        public void AddOrUpdate(Key key, Value value)
        {
            if (_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, value);
                return;
            }
            _dictionary[key] = value;
        }

        public T GetValue<T>(Key key) where T : new ()
        {
            var strValue = _dictionary[key] as string;

            if (string.IsNullOrEmpty(strValue))
                return new T();
            return JsonConvert.DeserializeObject<T>(strValue);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(_dictionary);
        }
    }
}
