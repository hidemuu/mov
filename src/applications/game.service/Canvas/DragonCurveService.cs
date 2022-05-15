using Mov.Game.Models;
using Mov.Game.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Service.Canvas
{
    public class DragonCurveService : CanvasServiceBase
    {
        
        #region コンストラクター

        public DragonCurveService(IGameRepositoryCollection repository) : base(repository)
        {
        }

        #endregion コンストラクター

        #region メソッド

        public override void Initialize()
        {
            base.Initialize();
            Engine.Move(150, 300); //開始位置へ移動
        }

        public override void Run()
        {
            base.Run();
        }

        protected override void Ready()
        {
            
        }

        protected override void DrawScreen()
        {
            Draw(13, 300, 0, 1);
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 描画処理
        /// </summary>
        private void Draw(int n, double len, double angle, int sw)
        {
            if (n == 1)
            {
                //n=1なら線を一本書く（長さと角度で）
                Engine.Forward(len, angle, ScreenGraphics);
            }
            else
            {
                //n>1なら4回再帰呼び出しで描く
                var dl = len / (2 / Math.Sqrt(2));  //長さの縮小
                var da = Math.PI * 0.25 * sw;       //角度の計算（swで+-回転）
                //再帰描画
                Draw(n - 1, dl, angle - da, 1);     //-a回転
                Draw(n - 1, dl, angle + da, -1);    //+a回転
            }
        }

        #endregion 内部メソッド
    }
}
