using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters;
using DomainCrudCommon.Interfaces;
using DomainCrudCommon.Interfaces.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorkForJesus.RepoServiceImplementation.Repository
{
    public class JsonRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly Dictionary<int, TEntity> _entities;
        private readonly string _filePath;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private bool _isFileExist;

        public JsonRepository(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            _entities = new Dictionary<int, TEntity>();
            _filePath = filePath;
            _jsonSerializerSettings = new JsonSerializerSettings();
            _jsonSerializerSettings.Converters.Add(new StringEnumConverter());
            _jsonSerializerSettings.Formatting = Formatting.Indented;
            _jsonSerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            _jsonSerializerSettings.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;
            _jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            _isFileExist = File.Exists(filePath);
            if (_isFileExist)
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    var json = streamReader.ReadToEnd();
                    _entities = JsonConvert.DeserializeObject<Dictionary<int,
                        TEntity>>(json,
                            _jsonSerializerSettings);
                }
            }
        }

        public int Count => _entities.Count;

        public void Add(TEntity entity)
        {
            _entities[entity.Id] = entity;
            _Persist();
        }

        public bool Contains(int id)
        {
            return _entities.ContainsKey(id);
        }

        public TEntity Get(int id)
        {
            return _entities[id];
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Values.AsQueryable().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.Values.ToArray();
        }

        public void Remove(int id)
        {
            _entities.Remove(id);
            _Persist();
        }

        public void Update(TEntity updatedEntity)
        {
            _entities[updatedEntity.Id] = updatedEntity;
            _Persist();
        }

        private void _Persist()
        {
            CreateFileIfNotExist();
            using (var streamWriter = new StreamWriter(_filePath))
            {
                var json = JsonConvert.SerializeObject(_entities, _jsonSerializerSettings);
                streamWriter.Write(json);
            }
        }

        /// <summary>
        ///     Create the file if it's not exist
        /// </summary>
        private void CreateFileIfNotExist()
        {
            if (_isFileExist)
                return;
            using (File.Create(_filePath))
            {
            }
            _isFileExist = true;
        }
    }
}