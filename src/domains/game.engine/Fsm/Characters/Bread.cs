using Mov.Game.Models;
using Mov.Game.Models.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Game.Engine.Characters
{
    public class Bread : FsmCharacterBase
    {

        #region プロパティ

        public override int TypeCode { get; protected set; } = GameMap.BREAD;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.CornflowerBlue);

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        public Bread(IFsmGameEngine gameEngine) : base(gameEngine)
        {
            SetPosition(-100, -100);
        }


        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X - 2, Y - 2, 4, 4);
        }
        public override bool Move()
        {
            return false;
        }
        public override bool IsDamage()
        {
            return false;
        }
    }
}
