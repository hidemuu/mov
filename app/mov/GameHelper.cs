using Mov.Game.Service.Puzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ConsoleApp
{
    internal class GameHelper
    {
        #region プロパティ

        internal TowerOfHanoiGame TowerOfHanoi { get; }

        #endregion プロパティ

        /// <summary>
        /// コンストラクター
        /// </summary>
        internal GameHelper()
        {
            TowerOfHanoi = new TowerOfHanoiGame(3);
        }

        #region メソッド

        #endregion メソッド

    }
}
