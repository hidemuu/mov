using Mov.Core.Graphicers.Services.Controllers;
using Mov.Drawer.Models;
using Mov.Drawer.Service;

namespace Mov.Drawer.Controller.Canvas
{
    public abstract class CanvasServiceBase : GraphicControllerBase, IGraphicDrawerService
    {
        #region プロパティ

        /// <summary>
        /// リポジトリ
        /// </summary>
        protected IDrawerRepository Repository { get; private set; }

        /// <summary>
        /// 描画エンジン
        /// </summary>
        protected GraphicEngine DrawEngine { get; private set; }

        #endregion プロパティ

        #region コンストラクター

        public CanvasServiceBase(IDrawerRepository repository) : base()
        {
            Repository = repository;
            DrawEngine = new GraphicEngine();
        }

        #endregion コンストラクター
    }
}