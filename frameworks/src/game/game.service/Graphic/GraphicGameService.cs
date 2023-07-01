using Mov.Game.Engine;
using Mov.Game.Models;
using Mov.Game.Models.Entities.Schemas;
using System.Collections.Generic;

namespace Mov.Game.Service.Graphic
{
    public class GraphicGameService : IGameFacade
    {
        #region フィールド

        private readonly IFiniteStateMachineGameEngine finiteStateMachineGameEngine;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GraphicGameService(IFiniteStateMachineGameEngine finiteStateMachineGameEngine)
        {
            this.finiteStateMachineGameEngine = finiteStateMachineGameEngine;
        }

        public void Run()
        {
        }

        public IGraphicGame CreateGraphicGame()
        {
            return new PackmanGame(finiteStateMachineGameEngine);
        }

        /// <summary>
        /// ライフ取得
        /// </summary>
        /// <returns></returns>
        public int GetPlayerLife()
        {
            return finiteStateMachineGameEngine.GetPlayerLife();
        }

        public IEnumerable<int> GetLevels()
        {
            return finiteStateMachineGameEngine.GetLevels();
        }

        public Landmark GetLandmark()
        {
            return finiteStateMachineGameEngine.GetLandmark();
        }

        public override string ToString()
        {
            return finiteStateMachineGameEngine.ToString();
        }
    }
}