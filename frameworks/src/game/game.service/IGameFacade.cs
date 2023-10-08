using Mov.Game.Models.Schemas;
using System.Collections.Generic;

namespace Mov.Game.Service
{
    public interface IGameFacade
    {
        #region メソッド

        void Run();

        IGraphicGame CreateGraphicGame();

        #endregion メソッド
    }
}