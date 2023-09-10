using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Cruds
{
    public interface IReadAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> ReadAll();
        Task<TEntity> Read(Guid id);
    }
}
