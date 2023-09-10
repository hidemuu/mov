using System.Collections.Generic;

namespace Mov.Core.Functions.Controllers
{
    /// <summary>
    /// コントローラーのインターフェース
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// 実行
        /// </summary>
        /// <returns></returns>
        bool Execute();

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
