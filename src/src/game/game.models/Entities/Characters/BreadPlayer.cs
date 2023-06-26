using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Game.Models.Entities.Characters
{
    public class BreadPlayer : Player
    {
        /// <summary>
        /// 
        /// </summary>
        private Breadcrumbs breadcrumbs;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="breadcrumbs"></param>
        public BreadPlayer(IFiniteStateMachineGameEngine engine, Breadcrumbs breadcrumbs) : base(engine)
        {
            this.breadcrumbs = breadcrumbs;
        }

        public override bool Move()
        {
            var result = base.Move();
            if (Reached) breadcrumbs.Drop(Row, Col);
            return result;
        }

    }
}
