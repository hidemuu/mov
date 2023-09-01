namespace Mov.Core.Controllers.Services.Commands.Actions
{
    public interface IActionCommand
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
