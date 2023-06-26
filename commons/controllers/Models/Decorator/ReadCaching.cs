using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Models.Decorator
{
    public class ReadCaching<T> : IRead<T>
    {

        private readonly IRead<T> decorated;

        private Dictionary<Guid, T> cachedEntities = new Dictionary<Guid, T>();

        private IEnumerable<T> allCachedEntities;

        public ReadCaching(IRead<T> decorated)
        {
            this.decorated = decorated;
        }

        public T Read(Guid id)
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

        public IEnumerable<T> ReadAll()
        {
            if (allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            }
            return allCachedEntities;
        }
    }
}
