namespace DomainCrudCommon.Interfaces
{
    public interface ILoadObject
    {
        T Load<T>(string key) where T : new();
    }
}
