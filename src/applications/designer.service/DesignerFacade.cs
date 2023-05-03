using Mov.Designer.Engine;
using Mov.Designer.Engine.Persistences;
using Mov.Designer.Models;
using Mov.Layouts;
using Mov.Layouts.Contexts;
using Mov.Layouts.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Service
{
    public class DesignerFacade : IDesignerFacade
    {
        #region フィールド

        private readonly ILayoutContext context;

        #endregion フィールド

        #region プロパティ

        public ILayoutFacade LayoutFacade { get; }

        public IDesignerCommand Command { get; }

        public IDesignerQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerFacade(IEnumerable<IDesignerRepository> repositories)
        {
            var repository = repositories.FirstOrDefault();
            this.Query = new RepositoryDesignerQuery(repository);
            this.Command = new RepositoryDesignerCommand(repository);
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
