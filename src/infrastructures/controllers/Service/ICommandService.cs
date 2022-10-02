using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Service
{
    /// <summary>
    /// コマンドで制御するサービスのインターフェース
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// 単一コマンド実行
        /// </summary>
        /// <param name="command"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        bool ExecuteCommand(string command, string[] args);

        /// <summary>
        /// コマンドの一覧を取得
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetCommands();

        /// <summary>
        /// コマンドの存在チェック
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        bool ExistsCommand(string command);

        /// <summary>
        /// コマンドのヘルプを取得
        /// </summary>
        /// <returns></returns>
        string GetCommandHelp();
    }
}
