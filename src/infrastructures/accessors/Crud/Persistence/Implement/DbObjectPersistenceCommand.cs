using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistance.Implement
{
    public class DbObjectPersistenceCommand<TEntity> : IPersistenceCommand<TEntity>
    {
        public void Delete(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Post(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Posts(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public void Put(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
