﻿using Mov.Core.Accessors.Models.Entities;

namespace Mov.Core.Accessors
{
    /// <summary>
    /// アクセスの共通コンテキスト
    /// </summary>
    public interface IAccessContext
    {
        #region property

        /// <summary>
        /// ファイルパラメータ
        /// </summary>
        FileParameter FileParameter { get; }

        #endregion property

        #region method

        /// <summary>
        /// テキストファイルから読出
        /// </summary>
        string[] Read();

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