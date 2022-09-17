using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Drawer.Models
{
    public class GraphicEngine
    {
        #region フィールド

        private Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

        #endregion フィールド

        #region プロパティ

        public double LastX { get; set; } = 0;
        public double LastY { get; set; } = 0;

        #endregion プロパティ

        #region コンストラクター

        public GraphicEngine()
        {
        }

        #endregion コンストラクター

        #region メソッド

        public void Initialize()
        {
        }

        public void Move(double x, double y)
        {
            LastX = x;
            LastY = y;
        }

        public void Forward(double len, double angle, Graphics graphics)
        {
            var x = LastX + len * Math.Cos(angle);
            var y = LastY + len * Math.Sin(angle);
            DrawLine(LastX, LastY, x, y, graphics);
            Move(x, y);
        }

        public void Draw(int len, double angle, Graphics graphics)
        {
            Forward(len, angle, graphics);
        }

        public void Draw(int n, double len, double angle, Graphics graphics)
        {
            if (n == 1)
            {
                Forward(len, angle, graphics);
            }
            else
            {
                var l = len / (2 / Math.Sqrt(2) + 2);
                var a = Math.PI * 0.25;
                Draw(n - 1, l, angle, graphics);
                Draw(n - 1, l, angle - a, graphics);
                Draw(n - 1, l, angle + a, graphics);
                Draw(n - 1, l, angle, graphics);
            }
        }

        public void DrawLine(double x1, double y1, double x2, double y2, Graphics graphics)
        {
            graphics.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
            //graphics.Dispose();
        }

        #endregion メソッド
    }
}
