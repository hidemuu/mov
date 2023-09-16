using System;

namespace Mov.Core.Stores
{
    public interface IStoreCommand<TEntity, TKey> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity, TKey> Deleter { get; }
    }
}