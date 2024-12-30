using Mov.Core.Graphicers.Services.Controllers;

namespace Mov.Game.Service
{
    public interface IGraphicGameService
    {
        #region property

        IGraphicController GraphicController { get; }

        /// <summary>
        /// ゲームオーバー判定
        /// </summary>
        bool IsGameOver { get; set; }

        /// <summary>
        /// ステージクリア判定
        /// </summary>
        bool IsStageClear { get; set; }

        /// <summary>
        /// スコア
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// レベル
        /// </summary>
        int Level { get; set; }

        #endregion property

        #region method

        /// <summary>
        /// 初期化処理
        /// </summary>
        void Initialize();

        /// <summary>
        /// 次ステージ移行
        /// </summary>
        void Next();

        /// <summary>
        /// 待機処理
        /// </summary>
        void Wait();

        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode">キーコード</param>
        void SetKeyCode(int keyCode);

        #endregion method
    }
}