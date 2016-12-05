namespace DomainCrudCommon.Interfaces
{
    public interface IEntity : ISaveObject
    {
        int Id { get; set; }
    }
}