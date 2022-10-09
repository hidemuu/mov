using Mov.Utilities;
using System;
using System.Collections.Generic;

namespace Mov.Controllers
{
    /// <summary>
    /// コマンド実行クラス
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class CommandExecuter<TParameter, TResponse>
    {
        #region フィールド

        /// <summary>
        /// コマンドパラメータ
        /// </summary>
        private readonly TParameter parameter;

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        private CommandDictionary<TParameter, TResponse> handler { get; }

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="parameter"></param>
        public CommandExecuter(TParameter parameter, string endpoint)
        {
            this.parameter = parameter;
            var factory = new CommandFactory<TParameter, TResponse>();
            this.handler = factory.Create(endpoint);
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

        public string GetHelp()
        {
            var help = string.Empty;
            foreach (var commandHelp in GetCommandHelps())
            {
                help += commandHelp.Item1 + " : " + commandHelp.Item2 + UtilityConstants.NewLine;
            }
            help = help.TrimEnd(UtilityConstants.NewLine.ToCharArray());
            return help;
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