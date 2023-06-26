using System;
using System.Collections.Generic;
using System.Text;
using Mov.Controllers;

namespace Mov.Repositories.Services.Persistences
{
    public interface IPersistenceCommand<TEntity> : IDisposable
    {
        ISave<TEntity> Saver { get; }

        IDelete<TEntity> Deleter { get; }
    }
}
