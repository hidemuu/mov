using Mov.Core.Learnings.Models;
using Mov.Game.Models.Entities;
using Mov.Game.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Suite.GameClient.Recursive
{
    public class TowerOfHanoiGameClient : IRecursiveGameClient
    {
        
        #region property

        /// <summary>
        /// 塔
        /// </summary>
        public ConsCell[] Cons { get; }

        /// <summary>
        /// 円盤数
        /// </summary>
        public int N { get; }

        /// <summary>
        /// 円盤
        /// </summary>
        public IDrawer2D[] Drawers { get; }

        #endregion property

        #region constructor

        public TowerOfHanoiGameClient(int n, int frameWidth, int frameHeight) 
        {
            this.N = n;
            Cons = new ConsCell[] { ConsCell.Range(1, n + 1), ConsCell.Nil, ConsCell.Nil };
            Drawers = new Saucer[n];
            for (var i = 0; i < n; i++)
            {
                Drawers[i] = new Saucer(i, n, frameWidth, frameHeight);
            }
        }

        #endregion constructor

    }
}
