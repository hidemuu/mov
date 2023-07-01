using Mov.Game.Models;
using Mov.Game.Models.Entities.Schemas;
using System.Collections.Generic;

namespace Mov.Game.Engine
{
    public interface IGameFacade
    {
        #region メソッド

        void Run();

        IGraphicGame CreateGraphicGame();

        int GetPlayerLife();

        IEnumerable<int> GetLevels();

        Landmark GetLandmark();

        #endregion メソッド
    }
}