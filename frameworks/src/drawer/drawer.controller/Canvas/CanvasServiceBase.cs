using Mov.Core.Graphicers;
using Mov.Drawer.Models;

namespace Mov.Drawer.Service.Canvas
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
            this.Repository = repository;
            this.DrawEngine = new GraphicEngine();
        }

        #endregion コンストラクター
    }
}