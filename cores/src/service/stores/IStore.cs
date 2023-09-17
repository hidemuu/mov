using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Stores
{
    public interface IStore<TEntity, TKey>
    {
        IStoreQuery<TEntity, TKey> Query { get; }
        IStoreCommand<TEntity, TKey> Command { get; }

    }
}
