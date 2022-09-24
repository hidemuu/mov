using System.Collections.Generic;

namespace Mov.Controllers
{
    /// <summary>
    /// コマンド実行のベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CommandExecuterBase<TPamameter, TResponse> : ICommandExecuter<TResponse>
    {
        #region フィールド

        /// <summary>
        /// コマンドパラメータ
        /// </summary>
        private readonly TPamameter parameter;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        protected abstract IDictionary<string, ICommand<TPamameter, TResponse>> Handler { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="parameter"></param>
        public CommandExecuterBase(TPamameter parameter)
        {
            this.parameter = parameter;
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
            return Handler[command].Invoke(this.parameter, args);
        }

        /// <summary>
        /// コマンド一覧を取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCommands()
        {
            return Handler.Keys;
        }

        public bool Exists(string command)
        {
            return Handler.ContainsKey(command);
        }

        #endregion メソッド
    }
}