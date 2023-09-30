using Mov.Core.Layouts;
using Mov.Core.Layouts.Services.Facades;
using Mov.Designer.Engine;
using Mov.Designer.Engine.Cruds;
using Mov.Designer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Designer.Service
{
    public class DesignerFacade : IDesignerFacade
    {
        #region フィールド

        private readonly ILayoutContext context;

        #endregion フィールド

        #region プロパティ

        public ILayoutFacade LayoutFacade { get; }

        public IDesignerStoreCommand Command { get; }

        public IDesignerStoreQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerFacade(IEnumerable<IDesignerRepository> repositories)
        {
            var repository = repositories.FirstOrDefault();
            this.Query = new DesignerStoreQuery(repository);
            this.Command = new DesignerStoreCommand(repository);
            this.context = new DesignerContext(repository);
            this.LayoutFacade = new LayoutFacade(this.context);
        }

        #endregion コンストラクター

        #region メソッド

        public void Read()
        {
            this.context.Read();
        }

        public void Write()
        {
            this.context.Write();
        }

        #endregion メソッド
    }
}