using Mov.Drawer.Models;
using System;

namespace Mov.Drawer.Controller.Canvas
{
    public class KochCurveService : CanvasServiceBase
    {
        #region コンストラクター

        public KochCurveService(IDrawerRepository repository) : base(repository)
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
            DrawEngine.Move(50, 300); //開始位置へ移動
            Draw(5, 500, 0);
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 描画処理
        /// </summary>
        private void Draw(int n, double len, double angle)
        {
            if (n == 1)
            {
                //n=1なら線を一本書く（長さと角度で）
                DrawEngine.Forward(len, angle, ScreenGraphics);
            }
            else
            {
                //n>1なら4回再帰呼び出しで描く
                var dl = len / (2 / Math.Sqrt(2) + 2);   //長さの縮小
                var da = Math.PI * 0.25;
                //再帰描画
                Draw(n - 1, dl, angle);         //直進
                Draw(n - 1, dl, angle - da);    //-a回転
                Draw(n - 1, dl, angle + da);    //+a回転
                Draw(n - 1, dl, angle);         //直進
            }
        }

        #endregion 内部メソッド
    }
}