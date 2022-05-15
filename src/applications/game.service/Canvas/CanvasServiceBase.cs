using Mov.Game.Models;
using Mov.Game.Models.Engines;
using Mov.Game.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Game.Service.Canvas
{
    public abstract class CanvasServiceBase : DrawServiceBase, ICanvasService
    {
       
        #region プロパティ

        /// <summary>
        /// ゲームエンジン
        /// </summary>
        protected DrawEngine Engine { get; private set; }
        
        #endregion プロパティ

        #region コンストラクター

        public CanvasServiceBase(IGameRepositoryCollection repository) : base(repository)
        {
            this.Engine = new DrawEngine();
        }

        #endregion コンストラクター


    }
}
