using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Commands
{
	public interface IUiCommandController<TRequest, TResponse>
	{
		/// <summary>
		/// 実行処理
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		TResponse Invoke(string command, TRequest request);

		IReadOnlyDictionary<string, Func<TRequest, TResponse>> CreateCommandHandlers();

		/// <summary>
		/// コマンド一覧を取得
		/// </summary>
		/// <returns></returns>
		IEnumerable<string> GetCommands();

		IEnumerable<Tuple<string, string>> GetCommandHelps();

		string GetHelp();

		/// <summary>
		/// コマンドの存在チェック
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		bool Exists(string command);
	}
}
