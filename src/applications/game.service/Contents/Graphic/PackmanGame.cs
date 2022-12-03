using Mov.Accessors.Repository;
using Mov.Game.Engine;
using Mov.Game.Models;
using Mov.Game.Models.Maps;
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
    public class PackmanGame : IGraphicGame
    {
        #region フィールド

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        private readonly IFiniteStateMachineGameEngine engine;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// グラフィックコントローラー
        /// </summary>
        public GraphicControllerBase GraphicController { get; }

        /// <summary>
        /// ゲームオーバー判定
        /// </summary>
        public bool IsGameOver { get; set; }
        /// <summary>
        /// ステージクリア判定
        /// </summary>
        public bool IsStageClear { get; set; }
        /// <summary>
        /// スコア
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// レベル
        /// </summary>
        public int Level { get; set; }

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
        public PackmanGame(IFiniteStateMachineGameEngine engine)
        {
            this.engine = engine;
            this.GraphicController = new FiniteStateMachineGameGraphicController(engine);
            this.IsGameOver = engine.IsGameOver;
            this.IsStageClear = engine.IsStageClear;
            this.Score = engine.Score;
            this.Level = engine.Level;
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
            
            this.engine.Level++;
            TotalScore += this.engine.Score;
            this.engine.Score = 0;
            this.engine.Initialize();
            this.engine.IsStageClear = false;
            this.GraphicController.IsActive = true;
        }

        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode"></param>
        public void SetKeyCode(int keyCode)
        {
            this.engine.KeyCode = keyCode;
        }

        public void Wait()
        {
            this.GraphicController.Wait();
        }

        #endregion メソッド

    }
}