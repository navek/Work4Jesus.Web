using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work4Jesus.Domain;
using Work4Jesus.RepoService.Repositories;

namespace WorkForJesus.RepoServiceImplementation.Repository
{
    public class EventRepository: JsonRepository<Cevent> , IEventRepository
    {
        public EventRepository(string filePath) : base(filePath)
        {
        }
    }
}
