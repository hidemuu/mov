using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Engine.Characters
{
    public class Alien : FsmCharacterBase
    {
        #region フィールド
        /// <summary>
        /// 乱数
        /// </summary>
        protected static Random rnd = new Random();
        protected int nextDirection = 0;
        protected int[,] dirOffset = { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        
        private int[] tryPlan = { 1, 3, 2 };
        #endregion

        #region プロパティ

        public override int TypeCode { get; protected set; } = GameMap.ALIEN;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.IndianRed);

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        public Alien(IFsmGameEngine gameEngine) : base(gameEngine)
        {
        }

        #region メソッド
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X + 2, Y + 2, GameEngine.UnitWidth - 4, GameEngine.UnitHeight - 4);
        }
        /// <summary>
        /// 移動先を設定
        /// </summary>
        public virtual void NextMove()
        {
            NextMoveRandom();
        }
        /// <summary>
        /// ランダムな方向転換による移動
        /// </summary>
        public void NextMoveRandom()
        {
            nextDirection = rnd.NextDouble() < 0.005 ? (Direction + 1 + (int)((rnd.NextDouble() * 2) + 0.5)) % 4 : Direction;
        }

        /// <summary>
        /// 移動実行処理
        /// </summary>
        public void MoveExec()
        {
            var x1 = X + dirOffset[nextDirection, 0];
            var y1 = Y + dirOffset[nextDirection, 1];
            if (GameEngine.IsWall(x1, y1) || GameEngine.GetCollision(this, x1, y1) != GameMap.NONE)
            {
                nextDirection = (nextDirection + tryPlan[(int)(rnd.NextDouble() * 2.1)]) % 4;
                x1 = X + dirOffset[nextDirection, 0];
                y1 = Y + dirOffset[nextDirection, 1];
            }
            if (!GameEngine.IsWall(x1, y1) && GameEngine.GetCollision(this, x1, y1) == GameMap.NONE)
            {
                Direction = nextDirection;
                SetPosition(x1, y1);
            }
        }


        public override bool Move()
        {
            NextMove();
            MoveExec();
            return false;
        }

        public override bool IsDamage()
        {
            return false;
        }
        #endregion

    }
}
