namespace Mov.Core.Controllers
{
    public interface ICommand
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

        void Execute();

        #endregion メソッド
    }
}
