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
        Task PostAsync<TEntity>(string url, TEntity item);

        /// <summary>
        /// Delete
        /// </summary>
        Task DeleteAsync<TIdentifier>(string url, TIdentifier identifier);

        #endregion method
    }
}