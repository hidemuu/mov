using Mov.Core.Accessors.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Accessors
{
    /// <summary>
    /// external resource access client
    /// </summary>
    public interface IClient : IDisposable
    {
        #region property

        /// <summary>
        /// Endpoint for client
        /// </summary>
        PathValue Endpoint { get; }

        #endregion property

        #region method

        /// <summary>
        /// Get
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(string url);

        /// <summary>
        /// Post
        /// </summary>
        Task PostAsync<TEntity>(string url, TEntity entity);

        /// <summary>
        /// Put
        /// </summary>
        Task PutAsync<TEntity>(string url, TEntity entity);

        /// <summary>
        /// Delete
        /// </summary>
        Task DeleteAsync<TEntity>(string url, TEntity entity);

        #endregion method
    }
}