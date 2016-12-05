using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DomainCrudCommon.Interfaces.Repository
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Gets the number of entities in the repository.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        int Count { get; }

        /// <summary>
        /// Determines whether the repository contains an entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns><c>true</c> if the repository contains an entity with the specified id; otherwise, <c>false</c>.</returns>
        bool Contains(int id);

        /// <summary>
        /// Gets the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        TEntity Get(int id);

        /// <summary>
        /// Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{TEntity}.</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        IEnumerable<TEntity> GetAll();
    }
}
