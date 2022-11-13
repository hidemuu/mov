using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistence.Implement
{
    public class DbObjectPersistenceQuery<TEntity> : IPersistenceQuery<TEntity>
    {
        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(string param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Gets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Gets(string param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Read()
        {
            throw new NotImplementedException();
        }
    }
}
