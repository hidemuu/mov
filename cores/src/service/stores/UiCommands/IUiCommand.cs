namespace Mov.Core.Functions.Commands
{
    /// <summary>
    /// コマンドのインターフェース
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    public interface IUiCommand
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
        /// <param name="service">処理実装サービス</param>
        /// <param name="args">パラメータ</param>
        /// <returns></returns>
        void Invoke(string[] args);

        /// <summary>
        /// 説明
        /// </summary>
        /// <returns></returns>
        string Help();

        #endregion メソッド
    }
}
