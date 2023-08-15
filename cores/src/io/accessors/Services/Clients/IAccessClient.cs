using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.IO;

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
        string Read(string url);

        /// <summary>
        /// 書き込み
        /// </summary>
        /// <param name="isappend">追記モード（falseなら上書き保存）</param>
        void Write(string url, string writeString, bool isappend);

        #endregion method
    }
}