using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Repositories
{
    public interface IDbRepository<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        #region property

        string Endpoint { get; }

        #endregion property

        #region method

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(TKey key);

        Task PostAsync(TEntity item);

        #endregion method
    }
}
