using DomainCrudCommon;

namespace Work4Jesus.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}