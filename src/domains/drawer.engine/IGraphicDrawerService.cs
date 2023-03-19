using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Drawer.Engine
{
    public interface IGraphicDrawerService
    {
        #region プロパティ

        /// <summary>
        /// 画面幅
        /// </summary>
        int FrameWidth { get; }
        /// <summary>
        /// 画面高さ
        /// </summary>
        int FrameHeight { get; }

        #endregion プロパティ

        #region メソッド

        void Initialize();

        void Run();

        void Draw(Graphics graphics);

        #endregion メソッド
    }
}
