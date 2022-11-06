using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models
{
    public interface IGameService
    {
        #region プロパティ

        /// <summary>
        /// リポジトリ
        /// </summary>
        IGameRepository Repository { get; }

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

        void Run();

        IEnumerable<int> GetLevels();

        Landmark GetLandmark();

        #endregion メソッド
    }
}
