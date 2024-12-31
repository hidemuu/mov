namespace Mov.Core.Commands
{
    /// <summary>
    /// コマンドのインターフェース
    /// </summary>
    public interface IUiCommand<TRequest, TResponse>
    {
        #region プロパティ

        /// <summary>
        /// コマンド名
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// ショートカット名
        /// </summary>
        string ShortName { get; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="args">パラメータ</param>
        /// <returns></returns>
        TResponse Invoke(TRequest request);

        /// <summary>
        /// 説明
        /// </summary>
        /// <returns></returns>
        string Help();

        #endregion メソッド
    }
}
