using System.Collections.Generic;

namespace Mov.Core.Stores.Services.Readers.Decorators
{
    public class ReadCaching<TEntity, TKey> : IRead<TEntity, TKey>
    {

        private readonly IRead<TEntity, TKey> decorated;

        private Dictionary<TKey, TEntity> cachedEntities = new Dictionary<TKey, TEntity>();

        private IEnumerable<TEntity> allCachedEntities;

        public ReadCaching(IRead<TEntity, TKey> decorated)
        {
            this.decorated = decorated;
        }

        public TEntity Read(TKey id)
        {
            var foundEntity = cachedEntities[id];
            if (foundEntity == null)
            {
                foundEntity = decorated.Read(id);
                if (foundEntity != null)
                {
                    cachedEntities[id] = foundEntity;
                }
            }
            return foundEntity;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            }
            return allCachedEntities;
        }
    }
}
