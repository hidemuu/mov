using System;
using System.Collections.Generic;
using System.Text;
using Mov.Controllers;

namespace Mov.Repositories.Services.Persistences
{
    public interface IPersistenceQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
