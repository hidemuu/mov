using Mov.Game.Models.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Suite.GameClient.Recursive.Entities
{
    /// <summary>
    /// 円盤を表すクラス
    /// </summary>
    public class Saucer : IDrawer2D
    {
        #region field

        private int idx;
        private int n;
        private int x;
        private int y;
        private int width;
        private int height;
        private double formWidth;
        private double formHeight;
        private Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        public Saucer(int idx, int n, double formWidth, double formHeight)
        {
            this.idx = idx;
            this.n = n;
            this.formWidth = formWidth;
            this.formHeight = formHeight;
            width = (int)(formWidth * (0.3 - (n - idx) * 0.2 / n));
            height = (int)(formHeight / Math.Max(10, n) * 0.9);
            Move(0, n - idx - 1);
        }

        #endregion constructor

        #region method

        /// <summary>
        /// 座標設定
        /// </summary>
        /// <param name="tower"></param>
        /// <param name="level"></param>
        public void Move(int tower, int level)
        {
            x = (int)(formWidth * 0.5 + (tower - 1) * formWidth * 0.3 - width * 0.5);
            y = (int)(formHeight - (level + 1) * height - 1);
        }

        /// <summary>
        /// 描画
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(pen, x, y, width, height);
        }

        #endregion method
    }
}
