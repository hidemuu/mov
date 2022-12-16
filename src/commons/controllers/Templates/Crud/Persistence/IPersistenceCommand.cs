using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IPersistenceCommand<TEntity>
    {
        ISave<TEntity> Saver { get; }
        
        IDelete<TEntity> Deleter { get; }
    }
}
