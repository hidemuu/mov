using Mov.Core.Graphicers.Services.Controllers;
using Mov.Game.Models;
using Mov.Suite.GameEngine.Graphic.Controller;

namespace Mov.Suite.GameEngine.Graphic
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
        private readonly IFiniteStateMachineGameClient engine;

        #endregion フィールド

        #region プロパティ

        /// <summary>
        /// グラフィックコントローラー
        /// </summary>
        public IGraphicController GraphicController { get; }

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

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="service"></param>
        public PackmanGame(IFiniteStateMachineGameClient engine)
        {
            this.engine = engine;
            GraphicController = new FiniteStateMachineGameGraphicController(engine);
            IsGameOver = engine.IsGameOver;
            IsStageClear = engine.IsStageClear;
            Score = engine.Score;
            Level = engine.Level;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            GraphicController.Initialize();
        }

        public void Next()
        {
            engine.Level++;
            TotalScore += engine.Score;
            engine.Score = 0;
            engine.Initialize();
            engine.IsStageClear = false;
            GraphicController.IsActive = true;
        }

        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode"></param>
        public void SetKeyCode(int keyCode)
        {
            engine.KeyCode = keyCode;
        }

        public void Wait()
        {
            GraphicController.Wait();
        }

        #endregion メソッド
    }
}
