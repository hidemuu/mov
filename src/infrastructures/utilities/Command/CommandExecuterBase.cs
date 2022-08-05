using System.Collections.Generic;

namespace Mov.Utilities.Command
{
    /// <summary>
    /// コマンド実行のベースクラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CommandExecuterBase<T> : ICommandExecuter<T>
    {
        #region フィールド

        /// <summary>
        /// コマンドパラメータ
        /// </summary>
        private readonly T parameter;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// コマンドハンドラー
        /// </summary>
        protected abstract IDictionary<string, ICommand<T>> Handler { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="parameter"></param>
        public CommandExecuterBase(T parameter)
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
        public Response Invoke(string command)
        {
            return Handler[command].Invoke(this.parameter);
        }

        #endregion メソッド
    }
}