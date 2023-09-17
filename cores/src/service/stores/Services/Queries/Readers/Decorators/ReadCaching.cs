using System.Collections.Generic;

namespace Mov.Core.Stores.Services.Queries.Readers.Decorators
{
    public class ReadCaching<TEntity, TKey> : IRead<TEntity, TKey>
    {
        #region field

        private readonly IRead<TEntity, TKey> _decorated;

        private Dictionary<TKey, TEntity> _cachedEntities = new Dictionary<TKey, TEntity>();

        private IEnumerable<TEntity> _allCachedEntities;

        #endregion field

        #region constructor

        public ReadCaching(IRead<TEntity, TKey> decorated)
        {
            _decorated = decorated;
        }

        #endregion constructor

        #region method

        public IEnumerable<TEntity> ReadAll()
        {
            if (_allCachedEntities == null)
            {
                _allCachedEntities = _decorated.ReadAll();
            }
            return _allCachedEntities;
        }

        public TEntity Read(TKey id)
        {
            var foundEntity = _cachedEntities[id];
            if (foundEntity == null)
            {
                foundEntity = _decorated.Read(id);
                if (foundEntity != null)
                {
                    _cachedEntities[id] = foundEntity;
                }
            }
            return foundEntity;
        }

        #endregion method
    }
}
