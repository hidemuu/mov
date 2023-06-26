using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Models
{
    public interface IDatabase<TEntity, TKey>
    {
        TEntity Get(TKey key);

        void Delete(TKey key);

        void Put(TEntity value);

        void Post(TEntity value);


    }
}
