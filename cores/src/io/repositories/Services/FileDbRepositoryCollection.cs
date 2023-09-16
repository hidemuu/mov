using Mov.Core.Accessors;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mov.Core.Repositories.Services
{
    public class FileDbRepositoryCollection<TRepository, TEntity, TKey, TInstance>
        : IDbRepositoryCollection<TRepository, TEntity, TKey>
        where TRepository : IDbRepository<TEntity, TKey>
        where TEntity : IDbSchema<TKey>
        where TInstance : FileDbRepository<TEntity, TKey>
    {
        #region field

        public IDictionary<string, TRepository> _repositories;

        #endregion field

        #region constructor

        public FileDbRepositoryCollection(IClient client)
        {
            _repositories = new Dictionary<string, TRepository>();
        }

        public IEnumerable<string> GetKeys()
        {
            return _repositories.Keys;
        }

        #endregion constructor

        #region method

        TRepository IDbRepositoryCollection<TRepository, TEntity, TKey>.GetRepository(string key)
        {
            if (string.IsNullOrEmpty(key)) return _repositories[""];
            if (!_repositories.TryGetValue(key, out TRepository repository)) return default;
            return repository;
        }

        #endregion method

        #region inner method

        private void CreateRepository(IClient client)
        {
            var defaultRepository = (TRepository)Activator.CreateInstance(typeof(TInstance), client);
            var directories = GetDirectories(defaultRepository.Endpoint);
            _repositories.Add("", defaultRepository);
            foreach (var directory in directories)
            {
                _repositories.Add(directory.Name, (TRepository)Activator.CreateInstance(typeof(TInstance), client));
            }
        }

        private IEnumerable<DirectoryInfo> GetDirectories(string endpoint)
        {
            var directoryInfo = new DirectoryInfo(endpoint);
            if (!directoryInfo.Exists) return null;
            return directoryInfo.GetDirectories();
        }

        #endregion inner method

    }
}
