using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System.Text;

namespace Mov.Core.Accessors.Services.Serializer.FIles
{
    /// <summary>
    /// シリアライザーのインターフェース
    /// </summary>
    public interface IFileSerializer
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
        /// deserialize
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <returns></returns>
        TResponse Deserialize<TRequest, TResponse>(string url);
        /// <summary>
        /// serialize
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="obj"></param>
        TResponse Serialize<TRequest, TResponse>(string url, TRequest obj);

        #endregion method
    }
}
