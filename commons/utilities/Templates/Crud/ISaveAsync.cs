using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Controllers
{
    public interface ISaveAsync<TEntity>
    {
        Task Save(TEntity entity);
    }
}
