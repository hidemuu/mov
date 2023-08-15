using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System.Text;

namespace Mov.Core.Accessors.Services.Serializer
{
    /// <summary>
    /// シリアライザーのインターフェース
    /// </summary>
    public interface ISerializer
    {
        #region property

        /// <summary>
        /// The Base URL for the API.
        /// </summary>
        PathValue Endpoint { get; }

        /// <summary>
        /// Encoding
        /// </summary>
        EncodingValue Encoding { get; }

        #endregion property

        #region method

        /// <summary>
        /// 読み出し
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        TResponse Read<TRequest, TResponse>(string url);
        /// <summary>
        /// 書き込み
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="obj"></param>
        TResponse Write<TRequest, TResponse>(string url, TRequest obj);

        #endregion method
    }
}
