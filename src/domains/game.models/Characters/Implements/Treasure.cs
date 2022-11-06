using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Models.Characters
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

        public Treasure(IFsmGameEngine engine) : base(engine)
        {
        }

        #endregion コンストラクター

        #region メソッド

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X + Engine.UnitWidth / 4, Y + Engine.UnitHeight / 4, Engine.UnitWidth / 2, Engine.UnitHeight / 2);
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
