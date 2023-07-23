using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Models.Texts;
using System.IO;

namespace Mov.Core.Accessors
{
    /// <summary>
    /// アクセスの共通サービス
    /// </summary>
    public interface IFileService
    {
        #region property

        /// <summary>
        /// ファイルパス
        /// </summary>
        FileValue FileValue { get; }

        /// <summary>
        /// エンコード
        /// </summary>
        EncodingValue Encoding { get; }

        #endregion property

        #region method

        /// <summary>
        /// 存在チェック
        /// </summary>
        bool Exists();

        /// <summary>
        /// シリアライザー生成
        /// </summary>
        /// <returns></returns>
        ISerializer CreateSerializer();

        /// <summary>
        /// 読み出し
        /// </summary>
        /// <returns></returns>
        string Read(string url);

        /// <summary>
        /// テキストファイルから読出
        /// </summary>
        string[] ReadLines();

        /// <summary>
        /// 書き込み
        /// </summary>
        /// <param name="isappend">追記モード（falseなら上書き保存）</param>
        void Write(string url, string writeString, bool isappend);

        /// <summary>
        /// 一行分テキストファイルに書き込み
        /// </summary>
        /// <param name="line">書き込み文字列</param>
        /// <param name="isAdd">書込モード true：追加 false：上書き</param>
        bool WriteLine(string line, bool isAdd = true);

        /// <summary>
        /// バックアップ処理
        /// バックアップフォルダを生成し、対象ファイルをコピー
        /// </summary>
        /// <returns></returns>
        string BackUp(string backupDirectory);

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <returns></returns>
        bool Clear();

        #endregion method
    }
}