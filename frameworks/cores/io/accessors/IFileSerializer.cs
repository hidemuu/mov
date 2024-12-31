using Mov.Core.Accessors.Models;

namespace Mov.Core.Accessors
{
    /// <summary>
    /// シリアライザーのインターフェース
    /// </summary>
    public interface IFileSerializer
    {
        #region property

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
