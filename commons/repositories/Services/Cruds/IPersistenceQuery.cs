using System;
using System.Collections.Generic;
using System.Text;
using Mov.Utilities.Templates.Crud;

namespace Mov.Repositories.Services.Cruds
{
    public interface IPersistenceQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
