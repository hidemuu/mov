using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Repositories
{
    public interface IDbObjectRepository<TEntity, TKey> where TEntity : IDbObject<TKey>
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
