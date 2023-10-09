using Mov.Game.Models;
using Mov.Game.Service;

namespace Mov.Suite.GameClient.FiniteStateMechine.Entities
{
    public class BreadPlayer : Player
    {
        #region field

        /// <summary>
        ///
        /// </summary>
        private Breadcrumbs breadcrumbs;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="breadcrumbs"></param>
        public BreadPlayer(IFiniteStateMachineGameClient engine, Breadcrumbs breadcrumbs) : base(engine)
        {
            this.breadcrumbs = breadcrumbs;
        }

        #endregion constructor

        #region method

        public override bool Move()
        {
            var result = base.Move();
            if (Reached) breadcrumbs.Drop(Row, Col);
            return result;
        }

        #endregion method
    }
}