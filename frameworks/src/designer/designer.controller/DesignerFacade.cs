using Mov.Core.Layouts;
using Mov.Core.Layouts.Services.Facades;
using Mov.Designer.Models;
using Mov.Designer.Service;
using Mov.Designer.Service.Stores;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Designer.Controller
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
            Query = new DesignerStoreQuery(repository);
            Command = new DesignerStoreCommand(repository);
            context = new DesignerContext(repository);
            LayoutFacade = new LayoutFacade(context);
        }

        #endregion コンストラクター

        #region メソッド

        public void Read()
        {
            context.Read();
        }

        public void Write()
        {
            context.Write();
        }

        #endregion メソッド
    }
}