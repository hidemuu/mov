using Mov.Game.Models.Engines;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Models.Characters
{
    public class Wall : CharacterBase
    {
        #region プロパティ

        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.DarkGray);

        public override int TypeCode { get; protected set; } = GameMap.WALL;
        public override int Speed { get; protected set; } = 0;
        public override int Life { get; protected set; } = 1;

        #endregion プロパティ

        #region コンストラクター

        public Wall(FsmGameEngine gameEngine) : base(gameEngine)
        {
        }

        #endregion コンストラクター

        #region メソッド

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X, Y, GameEngine.UnitWidth, GameEngine.UnitHeight);
        }

        public override bool Move()
        {
            return false;
        }
        public override bool IsDamage()
        {
            return false;
        }

        #endregion メソッド
    }
}
