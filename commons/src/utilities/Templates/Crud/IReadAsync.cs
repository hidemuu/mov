using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Templates.Crud
{
    public interface IReadAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> ReadAll();
        Task<TEntity> Read(Guid id);
    }
}
