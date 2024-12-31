using Mov.Game.Models.ValueObjects;
using Mov.Game.Service;
using System.Drawing;

namespace Mov.Game.Service.FiniteStateMechines.Entities
{
    public class Treasure : FiniteStateMachineCharacterBase
    {
        #region property

        public override CharacterType Type { get; protected set; } = CharacterType.TREASURE;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.Green);

        #endregion property

        #region constructor

        public Treasure(IFiniteStateMachineGameClient engine) : base(engine)
        {
        }

        #endregion constructor

        #region method

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

        #endregion method
    }
}