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
        /// リポジトリ
        /// </summary>
        protected IGameDatabase Repository { get; private set; }

        /// <summary>
        /// 描画エンジン
        /// </summary>
        protected DrawEngine DrawEngine { get; private set; }
        
        #endregion プロパティ

        #region コンストラクター

        public CanvasServiceBase(IGameDatabase repository) : base()
        {
            this.Repository = repository;
            this.DrawEngine = new DrawEngine();
        }

        #endregion コンストラクター


    }
}
