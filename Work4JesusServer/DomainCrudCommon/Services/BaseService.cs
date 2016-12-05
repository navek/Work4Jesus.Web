using System;
using System.Diagnostics;
using DomainCrudCommon.Interfaces;
using DomainCrudCommon.Interfaces.Repository;

namespace DomainCrudCommon.Services
{
    public abstract class BaseService<TEntity> : BaseReadOnlyService<TEntity>, IService<TEntity> where TEntity : IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly NexIdResolver<TEntity> _idResolver;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if repository is null.</exception>
        protected BaseService(IRepository<TEntity> repository)
            : base(repository)
        {
            _repository = repository;
            _idResolver = new NexIdResolver<TEntity>(_repository);
        }


      

        /// <summary>
        /// Occurs when an entity is added.
        /// </summary>
        public event EventHandler<EventArgs<TEntity>> Added;

        /// <summary>
        /// Occurs before adding an entity.
        /// </summary>
        public event EventHandler<CancelEventArgs<TEntity>> Adding;

        /// <summary>
        /// Occurs when an entity is deleted.
        /// </summary>
        public event EventHandler<EventArgs<object>> Deleted;

        /// <summary>
        /// Occurs before deleting an entity.
        /// </summary>
        public event EventHandler<CancelEventArgs<object>> Deleting;

        /// <summary>
        /// Occurs when an entity is updated.
        /// </summary>
        public event EventHandler<EventArgs<TEntity>> Updated;

        /// <summary>
        /// Occurs before updating an entity.
        /// </summary>
        public event EventHandler<CancelEventArgs<TEntity>> Updating;

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.ArgumentException">Thrown if an entity with the same id already exists.</exception>
        public virtual void Add(TEntity entity)
        {
            _idResolver.ResolveForAdd(entity);
            if (!_repository.Contains(entity.Id))
            {
                var cancelEventArgs = new CancelEventArgs<TEntity>(entity);
                OnAdding(cancelEventArgs);
                if (!cancelEventArgs.Cancel)
                {
                    entity.Save();
                    _repository.Add(entity);
                    _idResolver.UpdateAdd();
                    OnAdded(entity);
                }
            }
            else
            {
                Debug.WriteLine($"{typeof(TEntity)} with id {entity.Id} already exists");
            }
        }

        /// <summary>
        /// Removes the entity with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if entity with the given id is not found.</exception>
        public virtual void Remove(int id)
        {
            if (_repository.Contains(id))
            {
                var cancelEventArgs = new CancelEventArgs<object>(id);
                OnDeleting(cancelEventArgs);
                if (!cancelEventArgs.Cancel)
                {
                    _repository.Remove(id);
                    _idResolver.UpdateForRemove(id);
                    OnDeleted(id);
                }
            }
            else
            {
                Debug.WriteLine($"{typeof(TEntity)} with id {id} was not found");
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if entity with the given id is not found.</exception>
        public virtual void Update(TEntity entity)
        {
            if (_repository.Contains(entity.Id))
            {
                var cancelEventArgs = new CancelEventArgs<TEntity>(entity);
                OnUpdating(cancelEventArgs);
                if (!cancelEventArgs.Cancel)
                {
                    entity.Save();
                    _repository.Update(entity);
                    OnUpdated(entity);
                }
            }
            else
            {
                Debug.WriteLine("{0} with id {1} was not found", typeof(TEntity), entity.Id);
            }
        }

        /// <summary>
        /// Raises the Added event.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void OnAdded(TEntity entity)
        {
            if (Added != null)
            {
                Added(this, new EventArgs<TEntity>(entity));
            }
        }

        /// <summary>
        /// Raises the Adding event.
        /// </summary>
        /// <param name="e">The CancelEventArgs.</param>
        protected virtual void OnAdding(CancelEventArgs<TEntity> e)
        {
            if (Adding != null)
            {
                Adding(this, e);
            }
        }

        /// <summary>
        /// Raises the Deleted event.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        protected virtual void OnDeleted(object entityId)
        {
            if (Deleted != null)
            {
                Deleted(this, new EventArgs<object>(entityId));
            }
        }

        /// <summary>
        /// Raises the Deleting event.
        /// </summary>
        /// <param name="e">The CancelEventArgs.</param>
        protected virtual void OnDeleting(CancelEventArgs<object> e)
        {
            if (Deleting != null)
            {
                Deleting(this, e);
            }
        }

        /// <summary>
        /// Raises the Updated event.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void OnUpdated(TEntity entity)
        {
            if (Updated != null)
            {
                Updated(this, new EventArgs<TEntity>(entity));
            }
        }

        /// <summary>
        /// Raises the Updating event.
        /// </summary>
        /// <param name="e">The CancelEventArgs.</param>
        protected virtual void OnUpdating(CancelEventArgs<TEntity> e)
        {
            if (Updating != null)
            {
                Updating(this, e);
            }
        }
    }
}
