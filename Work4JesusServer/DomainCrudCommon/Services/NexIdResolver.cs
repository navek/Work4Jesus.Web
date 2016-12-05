using System.Linq;
using DomainCrudCommon.Interfaces;
using DomainCrudCommon.Interfaces.Repository;

namespace DomainCrudCommon.Services
{
    public class NexIdResolver<TEntity> where TEntity : IEntity
    {
        private readonly IReadOnlyRepository<TEntity> _repository;
        private int _maxId;
        public NexIdResolver(IReadOnlyRepository<TEntity> repo )
        {
            _repository = repo;
            InitializeMaxId();
        }

        private void InitializeMaxId()
        {
            _maxId = 0;
            if (_repository.Count > 0)
            _maxId =_repository.GetAll().Max((entity) => entity.Id);
            _maxId++;
        }

        public void ResolveForAdd(TEntity entity)
        {
            if (entity.Id > 0)
                return;
            entity.Id = _maxId;
        }

        public void UpdateForRemove(int id)
        {
            if (id == (_maxId - 1))
                _maxId = id;
        }

        public void UpdateAdd()
        {
            _maxId ++;
        }

        //public bool Validate(TEntity entity)
        //{
        //    _maxId == entity.Id;
        //}
    }
}
