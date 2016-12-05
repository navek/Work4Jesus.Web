using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainCrudCommon.Interfaces.Repository;
using Work4Jesus.Domain;

namespace Work4Jesus.RepoService.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
