using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainCrudCommon.Interfaces;

namespace DomainCrudCommon.Services
{
    public interface IService<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Occurs when an entity is added.
        /// </summary>
        event EventHandler<EventArgs<TEntity>> Added;

        /// <summary>
        /// Occurs before adding an entity.
        /// </summary>
        event EventHandler<CancelEventArgs<TEntity>> Adding;

        /// <summary>
        /// Occurs when an entity is deleted.
        /// </summary>
        event EventHandler<EventArgs<object>> Deleted;

        /// <summary>
        /// Occurs before deleting an entity.
        /// </summary>
        event EventHandler<CancelEventArgs<object>> Deleting;

        /// <summary>
        /// Occurs when an entity is updated.
        /// </summary>
        event EventHandler<EventArgs<TEntity>> Updated;

        /// <summary>
        /// Occurs before updating an entity.
        /// </summary>
        event EventHandler<CancelEventArgs<TEntity>> Updating;

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.ArgumentException">Thrown if an entity with the same id already exists.</exception>
        void Add(TEntity entity);

        /// <summary>
        /// Removes the entity with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if entity with the given id is not found.</exception>
        void Remove(int id);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if entity with the given id is not found.</exception>
        void Update(TEntity entity);

        /// <summary>
        /// Count of entities.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        int Count();

        /// <summary>
        /// Checks whether an entity with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns><c>true</c> if entity exists, <c>false</c> otherwise.</returns>
        bool Exists(int id);

        /// <summary>
        /// Gets the entity with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>The entity.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if an entity with the given id is not found.</exception>
        TEntity Get(int id);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>IEnumerable of entities.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{TEntity}.</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}