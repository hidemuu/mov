using Mov.Core;
using System.Drawing;

namespace Mov.Game.Models.Entities.Characters
{
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    public class Player : FiniteStateMachineCharacterBase
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

        #endregion フィールド

        #region プロパティ

        public override CharacterType Type { get; protected set; } = CharacterType.PLAYER;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.CornflowerBlue);

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="engine"></param>
        public Player(IFiniteStateMachineGameEngine engine) : base(engine)
        {
        }

        #endregion コンストラクター

        #region メソッド

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X + 2, Y + 2, Engine.UnitWidth - 4, Engine.UnitHeight - 4);
        }

        /// <summary>
        /// 移動処理
        /// </summary>
        /// <returns>true:移動成功</returns>
        public override bool Move()
        {
            //移動量
            var dx = 0;
            var dy = 0;

            //押されているキーに対する処理
            switch (Engine.KeyCode)
            {
                case CoreConstants.KEY_CODE_LEFT: dx = -1; break;
                case CoreConstants.KEY_CODE_RIGHT: dx = 1; break;
                case CoreConstants.KEY_CODE_UP: dy = -1; break;
                case CoreConstants.KEY_CODE_DOWN: dy = 1; break;
                default: return false;
            }

            if (IsMiddlePosition)
            {
                //1マスの中間位置は移動継続
                dx = lastDx;
                dy = lastDy;
            }
            var x = X + dx * Speed;
            var y = Y + dy * Speed;
            //壁でなく他のキャラに衝突しなければ進む
            if (!Engine.IsWall(x, y) && Engine.GetCollision(this, x, y) == (int)CharacterType.NONE)
            {
                SetPosition(x, y);
                lastDx = dx;
                lastDy = dy;
                return true;
            }
            //敵に衝突した時
            if (Engine.GetCollision(this, x, y) == (int)CharacterType.ALIEN) isCollision = true;
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

        /// <summary>
        /// 中間位置判定
        /// </summary>
        private bool IsMiddlePosition => X % Engine.UnitWidth != 0 || Y % Engine.UnitHeight != 0;

        #endregion メソッド
    }
}