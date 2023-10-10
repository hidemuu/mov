using Mov.Core.Models;
using System;
using System.Collections.Generic;

namespace Mov.Core.Commands.Services
{
    /// <summary>
    /// コマンド実行クラス
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public class UiCommandExecuter<TParameter, TResponse>
    {
        #region field

        /// <summary>
        /// コマンドパラメータ
        /// </summary>
        private readonly TParameter _parameter;

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        private UiCommandDictionary<TParameter, TResponse> _handler { get; }

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="parameter"></param>
        public UiCommandExecuter(TParameter parameter, string endpoint)
        {
            this._parameter = parameter;
            var factory = new UiCommandFactory<TParameter, TResponse>();
            _handler = factory.Create(endpoint);
        }

        #endregion constructor

        #region method

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public void Invoke(string command, string[] args)
        {
            _handler[command].Invoke(args);
        }

        /// <summary>
        /// コマンド一覧を取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCommands()
        {
            return _handler.Keys;
        }

        public IEnumerable<Tuple<string, string>> GetCommandHelps()
        {
            var commandHelps = new List<Tuple<string, string>>();
            foreach (var command in _handler)
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
            return _handler.ContainsKey(command);
        }

        #endregion method
    }
}