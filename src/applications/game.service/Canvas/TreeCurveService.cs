using Mov.Game.Models;
using Mov.Game.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Service.Canvas
{
    public class TreeCurveService : CanvasServiceBase
    {
        #region フィールド

        /// <summary>
        /// ランダムジェネレータ
        /// </summary>
        private Random rnd = new Random();

        #endregion フィールド

        #region コンストラクター

        public TreeCurveService(IGameRepositoryCollection repository) : base(repository)
        {
            
        }

        #endregion コンストラクター

        #region メソッド

        public override void Initialize()
        {
            base.Initialize();
            Engine.Move(300, 600); //開始位置へ移動
        }

        protected override void Ready()
        {

        }

        protected override void DrawScreen()
        {
            Draw(7, 450, Math.PI * -0.5, 1, ScreenGraphics);
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 描画処理
        /// </summary>
        private void Draw(int n, double len, double angle, int sw, Graphics graphics)
        {
            var x = Engine.LastX;
            var y = Engine.LastY;
            if (n == 1)
            {
                //n=1なら線を一本書く（長さと角度で）
                Engine.Forward(len, angle, graphics);
            }
            else
            {
                //n>1なら3回再帰呼び出しで描く
                var dl = len / (2 / Math.Sqrt(2));  //長さの縮小
                var da = Math.PI * 0.15 * sw;       //角度の計算（swで+-回転）
                angle += angle * (0.5 - rnd.NextDouble()) * 0.1;    //角度にゆらぎを与える
                //再帰描画
                Engine.Forward(dl * 0.33, angle, graphics);
                Draw(n - 1, dl * 0.8, angle - da, 1, graphics);   //-a回転

                Engine.Forward(dl * 0.33, angle, graphics);
                Draw(n - 1, dl * 0.7, angle + da, -1, graphics);  //+a回転, sw反転

                Engine.Forward(dl * 0.33, angle, graphics);
                Draw(n - 1, dl * 0.6, angle, 1, graphics);        //直進
            }
            Engine.LastX = x;
            Engine.LastY = y;
        }

        #endregion 内部メソッド
    }
}
