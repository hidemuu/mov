using Mov.Core.Graphicers.Services.Controllers;
using Mov.Game.Controller.Graphic;
using Mov.Game.Service;

namespace Mov.Game.Controller
{
    /// <summary>
    /// パックマンっぽいゲームサービス
    /// </summary>
    public class PackmanGraphicGame : IGraphicGame
    {
        #region field

        /// <summary>
        /// ゲームクライアント
        /// </summary>
        private readonly IFiniteStateMachineGameClient _client;

        #endregion field

        #region property

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

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="service"></param>
        public PackmanGraphicGame(IFiniteStateMachineGameClient client)
        {
            this._client = client;
            GraphicController = new FiniteStateMachineGameGraphicController(client);
            IsGameOver = client.IsGameOver;
            IsStageClear = client.IsStageClear;
            Score = client.Score;
            Level = client.Level;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
            GraphicController.Initialize();
        }

        public void Next()
        {
            _client.Level++;
            TotalScore += _client.Score;
            _client.Score = 0;
            _client.Initialize();
            _client.IsStageClear = false;
            GraphicController.IsActive = true;
        }

        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode"></param>
        public void SetKeyCode(int keyCode)
        {
            _client.KeyCode = keyCode;
        }

        public void Wait()
        {
            GraphicController.Wait();
        }

        #endregion method
    }
}
