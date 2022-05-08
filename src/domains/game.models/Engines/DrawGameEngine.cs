using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Models.Engines
{
    public class DrawGameEngine
    {
        #region フィールド

        private Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

        #endregion フィールド

        #region プロパティ

        public double LastX { get; set; } = 0;
        public double LastY { get; set; } = 0;


        /// <summary>
        /// グラフィック
        /// </summary>
        protected Graphics ScreenGraphics { get; private set; }

        #endregion プロパティ

        #region コンストラクター

        public DrawGameEngine()
        {

        }

        #endregion コンストラクター

        #region メソッド

        public void Move(double x, double y)
        {
            LastX = x;
            LastY = y;
        }

        public void Forward(double len, double angle)
        {
            var x = LastX + len + Math.Cos(angle);
            var y = LastY + len + Math.Sin(angle);
            DrawLine(LastX, LastY, x, y);
            Move(x, y);
        }

        public void Draw(int len, double angle)
        {
            Forward(len, angle);
        }

        public void Draw(int n, double len, double angle)
        {
            if (n == 1)
            {
                Forward(len, angle);
            }
            else
            {
                var l = len / (2 / Math.Sqrt(2) + 2);
                var a = Math.PI * 0.25;
                Draw(n - 1, l, angle);
                Draw(n - 1, l, angle - a);
                Draw(n - 1, l, angle + a);
                Draw(n - 1, l, angle);
            }
        }

        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            ScreenGraphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            //ScreenGraphics.Dispose();
        }

        #endregion メソッド
    }
}
