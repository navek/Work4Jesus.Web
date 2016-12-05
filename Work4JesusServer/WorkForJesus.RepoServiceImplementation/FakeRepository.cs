using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DomainCrudCommon.Interfaces;
using DomainCrudCommon.Interfaces.Repository;

namespace WorkForJesus.RepoServiceImplementation.Repository
{
    public class FakeRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        ///     Gets the entities.
        /// </summary>
        /// <value>The entities.</value>
        protected Dictionary<int, TEntity> Entities { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FakeRepository{TEntity, TId}" /> class.
        /// </summary>
        public FakeRepository()
        {
            Entities = new Dictionary<int, TEntity>();
        }

        /// <summary>
        ///     Gets the number of entities in the repository.
        /// </summary>
        /// <value>The total number of entities.</value>
        public int Count
        {
            get { return Entities.Count; }
        }

        /// <summary>
        ///     Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            Entities[entity.Id] = entity;
        }

        /// <summary>
        ///     Determines whether the repository contains an entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns><c>true</c> if the repository contains an entity with the specified id; otherwise, <c>false</c>.</returns>
        public bool Contains(int id)
        {
            return Entities.ContainsKey(id);
        }

        /// <summary>
        ///     Gets the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        public TEntity Get(int id)
        {
            TEntity entity;
            Entities.TryGetValue(id, out entity);
            return entity;
        }

        /// <summary>
        ///     Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{E}.</returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Values.AsQueryable().Where(predicate);
        }

        /// <summary>
        ///     Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Entities.Values.ToList();
        }

        /// <summary>
        ///     Removes the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        public void Remove(int id)
        {
            Entities.Remove(id);
        }

        /// <summary>
        ///     Updates the specified updated entity.
        /// </summary>
        /// <param name="updatedEntity">The updated entity.</param>
        public void Update(TEntity updatedEntity)
        {
            Entities[updatedEntity.Id] = updatedEntity;
        }
    }
}