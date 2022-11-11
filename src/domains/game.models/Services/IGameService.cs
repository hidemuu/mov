using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameService
    {
        #region プロパティ

        #endregion プロパティ

        #region メソッド

        void Run();

        IGraphicGame CreateGraphicGame();

        int GetPlayerLife();

        IEnumerable<int> GetLevels();

        Landmark GetLandmark();

        #endregion メソッド
    }
}
