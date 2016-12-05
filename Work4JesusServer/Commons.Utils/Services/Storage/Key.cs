using System;

namespace Commons.Utils.Services.Storage
{
    public class Key
    {
        public Key(string value)
        {
            Value = value;
            CreationDate = DateTime.UtcNow;
        }

        public Key(string value, DateTime creationDate)
        {
            Value = value;
            CreationDate = creationDate;
        }

        public Key()
        {
        }

        public string Value { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}