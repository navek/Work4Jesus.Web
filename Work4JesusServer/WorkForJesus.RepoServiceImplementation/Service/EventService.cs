using DomainCrudCommon.Services;
using Work4Jesus.Domain;
using Work4Jesus.RepoService;
using Work4Jesus.RepoService.Repositories;

namespace WorkForJesus.RepoServiceImplementation.Service
{
    public class EventService : BaseService<Cevent>, IEventService
    {
        public EventService(IEventRepository repository) : base(repository)
        {
        }
    }
}