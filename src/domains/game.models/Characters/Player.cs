using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Models.Characters
{
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    public class Player : CharacterBase
    {
        #region フィールド

        /// <summary>
        /// 前回移動量X
        /// </summary>
        private int lastDx = -1;
        /// <summary>
        /// 前回移動量Y
        /// </summary>
        private int lastDy = -1;

        private bool isCollision = false;
        
        #endregion

        #region プロパティ

        public override int TypeCode { get; protected set; } = PLAYER;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.CornflowerBlue);


        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        public Player(GameEngine gameEngine) : base(gameEngine)
        {
        }

        #region メソッド

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X + 2, Y + 2, GameEngine.UnitWidth - 4, GameEngine.UnitHeight - 4);
        }

        public override bool Move()
        {
            //移動量
            var dx = 0;
            var dy = 0;

            if(GameEngine.KeyCode == GameEngine.KEY_CODE_NONE)
            {
                //  キーが離された後の状態
                if (X % GameEngine.UnitWidth != 0 || Y % GameEngine.UnitHeight != 0)
                {
                    //1マスの中間位置は移動継続
                    dx = lastDx;
                    dy = lastDy;
                }
                else
                {
                    GameEngine.KeyCode = GameEngine.KEY_CODE_NONE;
                    return false;
                }
            }
            else
            {
                //押されているキーに対する処理
                switch (GameEngine.KeyCode)
                {
                    case GameEngine.KEY_CODE_LEFT: dx = -1; break;
                    case GameEngine.KEY_CODE_RIGHT: dx = 1; break;
                    case GameEngine.KEY_CODE_UP: dy = -1; break;
                    case GameEngine.KEY_CODE_DOWN: dy = 1; break;
                    default: return false;
                }
            }

            //壁でなく他のキャラに衝突しなければ進む
            var x = X + (dx * Speed);
            var y = Y + (dy * Speed);
            if (!GameEngine.IsWall(x, y) && GameEngine.GetCollision(this, x, y) == CharacterBase.NONE)
            {
                SetPosition(x, y);
                lastDx = dx;
                lastDy = dy;
                return true;
            }
            if (GameEngine.GetCollision(this, x, y) == CharacterBase.ALIEN) isCollision = true;
            return false;
        }

        /// <summary>
        /// ダメージ判定
        /// </summary>
        /// <returns></returns>
        public override bool IsDamage()
        {
            if (isCollision) return true;
            return false;
        }

        #endregion

    }
}
