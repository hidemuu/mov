using Mov.Core.Templates.Crud;
using System;

namespace Mov.Core.Repositories.Cruds
{
    public interface IPersistenceCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}
