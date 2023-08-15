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
    public interface IAccessClient : IDisposable
    {
        #region property

        /// <summary>
        /// パス
        /// </summary>
        PathValue Path { get; }

        /// <summary>
        /// エンコード
        /// </summary>
        EncodingValue Encoding { get; }

        #endregion property

        #region method

        /// <summary>
        /// 読み出し
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync<TEntity>(string url);

        /// <summary>
        /// 書き込み
        /// </summary>
        Task PostAsync<TEntity>(string url, TEntity item);

        #endregion method
    }
}