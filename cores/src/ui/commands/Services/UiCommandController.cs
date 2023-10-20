using Mov.Core.Models;
using System;
using System.Collections.Generic;

namespace Mov.Core.Commands.Services
{
    /// <summary>
    /// コマンド実行クラス
    /// </summary>
    public class UiCommandController<TRequest, TResponse> : IUiCommandController<TRequest, TResponse>
    {
        #region field

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        private UiCommandDictionary<TRequest, TResponse> _handler { get; }

		#endregion field

		#region constructor

		/// <summary>
		/// コンストラクター
		/// </summary>
		public UiCommandController(IUiCommandFactory<TRequest, TResponse> factory, string endpoint, params object[] args)
        {
            _handler = factory.Create(endpoint, args);
        }

        #endregion constructor

        #region method

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public TResponse Invoke(string command, TRequest request)
        {
            return _handler[command].Invoke(request);
        }

		public IReadOnlyDictionary<string, Func<TRequest, TResponse>> CreateCommandHandlers()
		{
			var dictionary = new Dictionary<string, Func<TRequest, TResponse>>();
			foreach (var kvp in _handler)
			{
				dictionary.Add(kvp.Key, kvp.Value.Invoke);
			}
			return dictionary;
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