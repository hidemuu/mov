using Mov.Drawer.Models;
using Mov.Drawer.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Drawer.Service.Canvas
{
    public abstract class CanvasServiceBase : DrawServiceBase, ICanvasService
    {

        #region プロパティ

        /// <summary>
        /// リポジトリ
        /// </summary>
        protected IDrawerRepository Repository { get; private set; }

        /// <summary>
        /// 描画エンジン
        /// </summary>
        protected DrawEngine DrawEngine { get; private set; }
        
        #endregion プロパティ

        #region コンストラクター

        public CanvasServiceBase(IDrawerRepository repository) : base()
        {
            this.Repository = repository;
            this.DrawEngine = new DrawEngine();
        }

        #endregion コンストラクター


    }
}
