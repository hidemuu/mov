using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Crud
{
    public interface IReadAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> ReadAll();
        Task<TEntity> Read(Guid id);
    }
}
