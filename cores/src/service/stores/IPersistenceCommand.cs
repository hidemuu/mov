using System;

namespace Mov.Core.Stores
{
    public interface IPersistenceCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}