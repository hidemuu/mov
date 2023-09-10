using Mov.Core.Models;
using System;
using System.Collections.Generic;

namespace Mov.Core.Functions.Commands.UI
{
    /// <summary>
    /// コマンド実行クラス
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class UiCommandExecuter<TParameter, TResponse>
    {
        #region フィールド

        /// <summary>
        /// コマンドパラメータ
        /// </summary>
        private readonly TParameter parameter;

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        private UiCommandDictionary<TParameter, TResponse> handler { get; }

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="parameter"></param>
        public UiCommandExecuter(TParameter parameter, string endpoint)
        {
            this.parameter = parameter;
            var factory = new UiCommandFactory<TParameter, TResponse>();
            handler = factory.Create(endpoint);
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
            return handler[command].Invoke(parameter, args);
        }

        /// <summary>
        /// コマンド一覧を取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCommands()
        {
            return handler.Keys;
        }

        public IEnumerable<Tuple<string, string>> GetCommandHelps()
        {
            var commandHelps = new List<Tuple<string, string>>();
            foreach (var command in handler)
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
                help += commandHelp.Item1 + " : " + commandHelp.Item2 + NewLineCode.CRLF.Value;
            }
            help = help.TrimEnd(NewLineCode.CRLF.Value.ToCharArray());
            return help;
        }

        /// <summary>
        /// コマンドの存在チェック
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool Exists(string command)
        {
            return handler.ContainsKey(command);
        }

        #endregion メソッド
    }
}