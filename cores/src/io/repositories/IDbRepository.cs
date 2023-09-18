using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Repositories
{
    /// <summary>
    /// repository for database
    /// </summary>
    /// <typeparam name="TEntity">entity</typeparam>
    /// <typeparam name="TIdentifier">identifier</typeparam>
    public interface IDbRepository<TEntity, TIdentifier> where TEntity : IDbSchema<TIdentifier>
    {
        #region property

        string Endpoint { get; }

        #endregion property

        #region method

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(TIdentifier identifier);

        Task PostAsync(TEntity entity);

        Task PutAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(TIdentifier identifier);

        #endregion method
    }
}
