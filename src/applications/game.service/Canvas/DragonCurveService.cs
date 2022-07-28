using Mov.Game.Models;
using Mov.Game.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Service.Canvas
{
    public class DragonCurveService : CanvasServiceBase
    {
        
        #region コンストラクター

        public DragonCurveService(IGameDatabase repository) : base(repository)
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
            DrawEngine.Move(150, 300); //開始位置へ移動
            Draw(13, 300, 0, 1, ScreenGraphics);
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 描画処理
        /// </summary>
        private void Draw(int n, double len, double angle, int sw, Graphics graphics)
        {
            if (n == 1)
            {
                //n=1なら線を一本書く（長さと角度で）
                DrawEngine.Forward(len, angle, graphics);
            }
            else
            {
                //n>1なら4回再帰呼び出しで描く
                var dl = len / (2 / Math.Sqrt(2));  //長さの縮小
                var da = Math.PI * 0.25 * sw;       //角度の計算（swで+-回転）
                //再帰描画
                Draw(n - 1, dl, angle - da, 1, graphics);     //-a回転
                Draw(n - 1, dl, angle + da, -1, graphics);    //+a回転
            }
        }

        #endregion 内部メソッド
    }
}
