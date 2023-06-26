using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Commands
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
