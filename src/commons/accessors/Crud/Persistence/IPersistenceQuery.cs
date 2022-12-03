using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IPersistenceQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
