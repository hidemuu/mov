using Mov.Core.Accessors.Models;
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

        Task<IEnumerable<TEntity>> GetsAsync();

        Task<TEntity> GetAsync(TIdentifier identifier);

        Task<TEntity> GetRequestAsync(IDbRequestSchema request);

		Task<ResponseStatus> PostsAsync(IEnumerable<TEntity> entities);

		Task<ResponseStatus> PostAsync(TEntity entity);

		Task<ResponseStatus> PutAsync(TEntity entity);

        Task<ResponseStatus> DeleteAsync(TEntity entity);

        #endregion method
    }
}
