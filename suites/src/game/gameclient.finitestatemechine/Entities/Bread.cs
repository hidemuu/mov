using Mov.Game.Models;
using Mov.Game.Models.Entities;
using System.Drawing;

namespace Mov.Suite.GameClient.FiniteStateMechine.Entities
{
    public class Bread : FiniteStateMachineCharacterBase
    {
        #region property

        public override CharacterType Type { get; protected set; } = CharacterType.BREAD;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.CornflowerBlue);

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="engine"></param>
        public Bread(IFiniteStateMachineGameClient engine) : base(engine)
        {
            SetPosition(-100, -100);
        }

        #endregion constructor

        #region method

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

        #endregion method
    }
}