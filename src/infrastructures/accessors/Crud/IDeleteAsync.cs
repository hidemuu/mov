using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Crud
{
    public interface IDeleteAsync<TEntity>
    {
        Task Delete(TEntity entity);
    }
}
