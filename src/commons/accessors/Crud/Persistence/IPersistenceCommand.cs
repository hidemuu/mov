using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IPersistenceCommand<TEntity>
    {
        ISave<TEntity> Saver { get; }
        
        IDelete<TEntity> Deleter { get; }
    }
}
