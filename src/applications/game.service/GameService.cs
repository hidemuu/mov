using Mov.Game.Models;
using Mov.Game.Service.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Game.Service
{
    public class GameService : IGameService
    {

        #region フィールド

        private readonly IFiniteStateMachineGameEngine finiteStateMachineGameEngine;

        #endregion フィールド

        #region プロパティ


        #endregion プロパティ

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GameService(IFiniteStateMachineGameEngine finiteStateMachineGameEngine)
        {
            this.finiteStateMachineGameEngine = finiteStateMachineGameEngine;
        }

        public void Run()
        {
            
        }

        public IGraphicGame CreateGraphicGame()
        {
            return new PackmanGame(this.finiteStateMachineGameEngine);
        }

        /// <summary>
        /// ライフ取得
        /// </summary>
        /// <returns></returns>
        public int GetPlayerLife()
        {
            return this.finiteStateMachineGameEngine.GetPlayerLife();
        }

        public IEnumerable<int> GetLevels()
        {
            return this.finiteStateMachineGameEngine.GetLevels();
        }

        public Landmark GetLandmark()
        {
            return this.finiteStateMachineGameEngine.GetLandmark();
        }

        public override string ToString()
        {
            return this.finiteStateMachineGameEngine.ToString();
        }
    }
}
