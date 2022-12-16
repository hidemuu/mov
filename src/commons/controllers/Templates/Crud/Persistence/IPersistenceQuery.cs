using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IPersistenceQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
