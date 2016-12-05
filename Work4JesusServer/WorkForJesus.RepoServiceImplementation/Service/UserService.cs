using DomainCrudCommon.Services;
using Work4Jesus.Domain;
using Work4Jesus.RepoService;
using Work4Jesus.RepoService.Repositories;

namespace WorkForJesus.RepoServiceImplementation.Service
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}