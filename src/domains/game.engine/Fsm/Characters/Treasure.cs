using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Engine.Characters
{
    public class Treasure : FsmCharacterBase
    {
        #region プロパティ

        public override int TypeCode { get; protected set; } = GameMap.TREASURE;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.Green);

        #endregion プロパティ

        #region コンストラクター

        public Treasure(IFsmGameEngine gameEngine) : base(gameEngine)
        {
        }

        #endregion コンストラクター

        #region メソッド

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X + GameEngine.UnitWidth / 4, Y + GameEngine.UnitHeight / 4, GameEngine.UnitWidth / 2, GameEngine.UnitHeight / 2);
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
