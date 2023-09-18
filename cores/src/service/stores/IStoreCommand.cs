using System;

namespace Mov.Core.Stores
{
    public interface IStoreCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}