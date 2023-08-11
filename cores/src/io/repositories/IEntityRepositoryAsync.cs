using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Repositories
{
    public interface IEntityRepositoryAsync<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(string param);

        Task PostAsync(TEntity item);
    }
}
