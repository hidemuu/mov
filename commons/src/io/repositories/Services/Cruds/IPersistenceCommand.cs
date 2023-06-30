using Mov.Core.Templates.Crud;
using System;

namespace Mov.Core.Repositories.Services.Cruds
{
    public interface IPersistenceCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}
