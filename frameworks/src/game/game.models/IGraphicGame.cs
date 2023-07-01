using Mov.Core.Graphicers.Services;

namespace Mov.Game.Models
{
    public interface IGraphicGame
    {
        #region プロパティ

        GraphicControllerBase GraphicController { get; }

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

        #endregion プロパティ

        #region メソッド

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

        #endregion メソッド
    }
}