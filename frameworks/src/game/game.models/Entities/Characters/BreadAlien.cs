namespace Mov.Game.Models.Entities.Characters
{
    public class BreadAlien : Alien
    {
        /// <summary>
        ///
        /// </summary>
        private Breadcrumbs breadcrumbs;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameEngine"></param>
        /// <param name="breadcrumbs"></param>
        public BreadAlien(IFiniteStateMachineGameClient engine, Breadcrumbs breadcrumbs) : base(engine)
        {
            this.breadcrumbs = breadcrumbs;
        }

        public override void NextMove()
        {
            NextMoveBread();
        }

        public void NextMoveBread()
        {
            if (Reached)
            {
                var tryDir = breadcrumbs.Trail(Row, Col, Direction);
                if (tryDir != -1)
                {
                    nextDirection = tryDir;
                }
                else
                {
                    nextDirection = rnd.NextDouble() < 0.005 ? (Direction + (int)(1 + rnd.NextDouble() * 3)) % 4 : Direction;
                }
            }
            else
            {
                nextDirection = Direction;
            }
        }
    }
}