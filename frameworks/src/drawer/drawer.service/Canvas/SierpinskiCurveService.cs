using Mov.Drawer.Models;
using System;

namespace Mov.Drawer.Service.Canvas
{
    public class SierpinskiCurveService : CanvasServiceBase
    {
        #region コンストラクター

        public SierpinskiCurveService(IDrawerRepository repository) : base(repository)
        {
        }

        #endregion コンストラクター

        #region メソッド

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void Ready()
        {
        }

        protected override void DrawScreen()
        {
            Draw(6, 300, 300, 150);
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 描画処理
        /// </summary>
        private void Draw(int n, double len, double x, double y)
        {
            var dl = len / 2;
            if (n == 1)
            {
                //n=1なら線を３本使って３角形を書く
                var x1 = x - 1;
                var x2 = x + 1;
                var y1 = y + 1 * Math.Sqrt(3);
                DrawEngine.DrawLine(x, y, x1, y1, ScreenGraphics);
                DrawEngine.DrawLine(x1, y1, x2, y1, ScreenGraphics);
                DrawEngine.DrawLine(x2, y1, x, y, ScreenGraphics);
            }
            else
            {
                //n>1なら３角形３つを再帰呼び出しで描く
                var dl2 = dl / 2;  //長さの縮小
                //再帰描画
                Draw(n - 1, dl, x, y);                              //上の三角形
                Draw(n - 1, dl, x - dl2, y + dl2 * Math.Sqrt(3));   //左下の三角形
                Draw(n - 1, dl, x + dl2, y + dl2 * Math.Sqrt(3));   //右下の三角形
            }
        }

        #endregion 内部メソッド
    }
}