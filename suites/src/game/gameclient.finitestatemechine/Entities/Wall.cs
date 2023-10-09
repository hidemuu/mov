using Mov.Game.Models.Entities;
using Mov.Game.Service;
using System.Drawing;

namespace Mov.Suite.GameClient.FiniteStateMechine.Entities
{
    public class Wall : FiniteStateMachineCharacterBase
    {
        #region property

        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.DarkGray);

        public override CharacterType Type { get; protected set; } = CharacterType.WALL;
        public override int Speed { get; protected set; } = 0;
        public override int Life { get; protected set; } = 1;

        #endregion property

        #region constructor

        public Wall(IFiniteStateMachineGameClient engine) : base(engine)
        {
        }

        #endregion constructor

        #region method

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(BodyBrush, X, Y, Engine.UnitWidth, Engine.UnitHeight);
        }

        public override bool Move()
        {
            return false;
        }

        public override bool IsDamage()
        {
            return false;
        }

        #endregion method
    }
}