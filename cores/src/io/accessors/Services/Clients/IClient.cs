using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Services.Clients
{
    /// <summary>
    /// アクセスの共通サービス
    /// </summary>
    public interface IClient : IDisposable
    {
        #region property

        /// <summary>
        /// パス
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
        Task DeleteAsync<TEntity>(string url, TEntity item);

        #endregion method
    }
}