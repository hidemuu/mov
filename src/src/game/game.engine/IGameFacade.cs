using System;
using System.Collections.Generic;
using System.Text;
using Mov.Game.Models;
using Mov.Game.Models.Entities.Schemas;

namespace Mov.Game.Engine
{
    public interface IGameFacade
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
