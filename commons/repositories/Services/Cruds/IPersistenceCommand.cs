using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Templates.Crud;

namespace Mov.Repositories.Services.Cruds
{
    public interface IPersistenceCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}
