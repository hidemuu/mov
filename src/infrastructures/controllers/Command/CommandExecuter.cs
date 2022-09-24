using System;
using System.Collections.Generic;

namespace Mov.Controllers
{
    /// <summary>
    /// コマンド実行クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommandExecuter<TPamameter, TResponse>
    {
        #region フィールド

        /// <summary>
        /// コマンドパラメータ
        /// </summary>
        private readonly TPamameter parameter;

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        private IDictionary<string, ICommand<TPamameter, TResponse>> handler { get; }

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="parameter"></param>
        public CommandExecuter(TPamameter parameter, IDictionary<string, ICommand<TPamameter, TResponse>> handler)
        {
            this.parameter = parameter;
            this.handler = handler;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public TResponse Invoke(string command, string[] args)
        {
            return this.handler[command].Invoke(this.parameter, args);
        }

        /// <summary>
        /// コマンド一覧を取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCommands()
        {
            return this.handler.Keys;
        }

        public IEnumerable<Tuple<string, string>> GetCommandHelps()
        {
            var commandHelps = new List<Tuple<string, string>>();
            foreach(var command in this.handler)
            {
                commandHelps.Add(new Tuple<string, string>(command.Key, command.Value.Help()));
            }
            return commandHelps;
        }

        /// <summary>
        /// コマンドの存在チェック
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Exists(string command)
        {
            return this.handler.ContainsKey(command);
        }

        #endregion メソッド
    }
}