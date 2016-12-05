using System;
using Commons.Utils.Notifications;
using DomainCrudCommon.Interfaces;
using DomainCrudCommon.ValueRegisters;
using DomainCrudCommon.ValueRegisters.Interfaces;
using NHibernate.Proxy;

namespace DomainCrudCommon
{
    public abstract class Entity : NotificationBase, ILoadObject, IEntity
    {
        private readonly ValueRegister _valueRegister;
        private DictionnaryObject<string, string> _container;
        private string _dataValue;
        private bool _isLocked;
        protected IValueRegister ValueRegister => _valueRegister;

    

        protected Entity()
        {
            _valueRegister = new ValueRegister(this);
        }

        public virtual int Id { get; set; }

        T ILoadObject.Load<T>(string key)
        {
            return _container.GetValue<T>(key);
        }




        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }
        /// <summary>
        /// Save all value changes
        /// </summary>
        public void Save()
        {
            _valueRegister.Save();
        }

        private Type GetRealType()
        {
            return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        }
    }
}