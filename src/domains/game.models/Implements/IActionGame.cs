using Mov.Game.Models;
using Mov.Game.Models.Maps;
using Mov.Painters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Models
{
    public interface IActionGame
    {
        #region プロパティ

        IFiniteStateMachineGameEngine Engine { get; }

        GraphicControllerBase GraphicController { get; }

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
