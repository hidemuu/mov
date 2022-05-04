using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Service
{
    public interface IGameService
    {
        #region プロパティ

        bool IsGameOver { get; }

        bool IsStageClear { get; }
        
        int Score { get; }

        int Level { get; }

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
        /// 起動処理
        /// </summary>
        void Run();
        /// <summary>
        /// 終了処理
        /// </summary>
        void End();
        /// <summary>
        /// キーコード設定
        /// </summary>
        /// <param name="keyCode">キーコード</param>
        void SetKeyCode(int keyCode);
        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="g"></param>
        void Draw(Graphics graphics);

        int GetLife();

        void SetLevel(int lv);

        IEnumerable<int> GetLevels();

        Landmark GetLandmark();

        #endregion メソッド
    }
}
