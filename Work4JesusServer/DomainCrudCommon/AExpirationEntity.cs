using System;

namespace DomainCrudCommon
{
    public abstract class AExpirationEntity : Entity
    {
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }

        public bool HasExpired()
        {
            return DateTime.UtcNow - StartTime > Duration;
        }
    }
}