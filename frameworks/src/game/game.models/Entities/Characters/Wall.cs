using System.Drawing;

namespace Mov.Game.Models.Entities.Characters
{
    public class Wall : FiniteStateMachineCharacterBase
    {
        #region プロパティ

        protected override Brush BodyBrush { get; set; } = new SolidBrush(Color.DarkGray);

        public override CharacterType Type { get; protected set; } = CharacterType.WALL;
        public override int Speed { get; protected set; } = 0;
        public override int Life { get; protected set; } = 1;

        #endregion プロパティ

        #region コンストラクター

        public Wall(IFiniteStateMachineGameEngine engine) : base(engine)
        {
        }

        #endregion コンストラクター

        #region メソッド

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

        #endregion メソッド
    }
}