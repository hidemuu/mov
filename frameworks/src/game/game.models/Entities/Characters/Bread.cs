using System.Drawing;

namespace Mov.Game.Models.Entities.Characters
{
    public class Bread : FiniteStateMachineCharacterBase
    {
        #region プロパティ

        public override CharacterType Type { get; protected set; } = CharacterType.BREAD;
        public override int Speed { get; protected set; } = 1;
        public override int Life { get; protected set; } = 1;
        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.CornflowerBlue);

        #endregion プロパティ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="engine"></param>
        public Bread(IFiniteStateMachineGameClient engine) : base(engine)
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