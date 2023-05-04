using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Repository.Persistences
{
    public interface IPersistenceCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}
