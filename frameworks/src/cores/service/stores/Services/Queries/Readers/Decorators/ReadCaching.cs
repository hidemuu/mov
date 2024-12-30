using System.Collections.Generic;

namespace Mov.Core.Stores.Services.Queries.Readers.Decorators
{
    public class ReadCaching<TEntity, TIdentifier> : IRead<TEntity, TIdentifier>
    {
        #region field

        private readonly IRead<TEntity, TIdentifier> _decorated;

        private Dictionary<TIdentifier, TEntity> _cachedEntities = new Dictionary<TIdentifier, TEntity>();

        private IEnumerable<TEntity> _allCachedEntities;

        #endregion field

        #region constructor

        public ReadCaching(IRead<TEntity, TIdentifier> decorated)
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

        public TEntity Read(TIdentifier id)
        {
            if(!_cachedEntities.TryGetValue(id, out TEntity foundEntity))
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
