using Mov.Accessors.Repository;
using Mov.Game.Engine;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
using Mov.Game.Repository;
using Mov.Game.Service.Implements;
using Mov.Painters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Service.Machine
{
    /// <summary>
    /// パックマンっぽいゲームサービス
    /// </summary>
    public class PackmanGame : IActionGame
    {
        #region フィールド

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        public IFiniteStateMachineGameEngine Engine { get; }

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// グラフィックコントローラー
        /// </summary>
        public GraphicControllerBase GraphicController { get; }

        
        /// <summary>
        /// トータルスコア
        /// </summary>
        public int TotalScore { get; private set; } = 0;
        

        #endregion フィールド

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="service"></param>
        public PackmanGame(IGameService service)
        {
            this.Engine = new FiniteStateMachineGameEngine(service);
            this.GraphicController = new FiniteStateMachineGameGraphicController(this.Engine);
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            this.GraphicController.Initialize();
        }

        public void Next()
        {
            
            this.Engine.Service.Level++;
            TotalScore += this.Engine.Service.Score;
            this.Engine.Service.Score = 0;
            this.Engine.Initialize();
            this.Engine.Service.IsStageClear = false;
            this.GraphicController.IsActive = true;
        }

        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode"></param>
        public void SetKeyCode(int keyCode)
        {
            this.Engine.KeyCode = keyCode;
        }

        public void Wait()
        {
            this.GraphicController.Wait();
        }

        #endregion メソッド

    }
}