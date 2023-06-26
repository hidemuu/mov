using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Utilities.Templates.Crud
{
    public interface IDeleteAsync<TEntity>
    {
        Task Delete(TEntity entity);
    }
}
