using Mov.Designer.Models;
using Mov.Designer.Models.DomainModels;
using Mov.Designer.Models.Persistences;
using Mov.Layouts;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Service
{
    public class DesignerService : IDesignerService
    {
        #region フィールド

        private readonly IEnumerable<IDesignerEngine> engines;

        private IDesignerEngine engine;

        #endregion フィールド

        #region プロパティ

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerService(IEnumerable<IDesignerEngine> engines)
        {
            this.engines = engines;
            SetEngine(0);
        }

        #endregion コンストラクター

        #region メソッド

        public void SetEngine(int domainId)
        {
            this.engine = engines.FirstOrDefault(x => x.DomainId == domainId);
        }

        #region UIモデル

        public LayoutNode GetRegionNode(RegionStyle region)
        {
            if (region.IsCenter) return this.engine.CenterNode;
            if (region.IsTop) return this.engine.TopNode;
            if (region.IsBottom) return this.engine.BottomNode;
            if (region.IsLeft) return this.engine.LeftNode;
            if (region.IsRight) return this.engine.RightNode;
            return this.engine.CenterNode;
        }

        #endregion UIモデル

        #region クエリ

        public void Read()
        {
            this.engine.Read();
        }

        public IEnumerable<Node> GetNodes()
        {
            return this.engine.GetNodes();
        }

        public Node GetNode(Guid id)
        {
            return this.engine.GetNode(id);
        }

        public IEnumerable<Content> GetContents()
        {
            return this.engine.GetContents();
        }

        public Content GetContent(Guid id)
        {
            return this.engine.GetContent(id);
        }

        public Content GetContent(string code)
        {
            return this.engine.GetContent(code);
        }

        public IEnumerable<LayoutShell> GetShells()
        {
            foreach(var shell in this.engine.GetShells())
            {
                yield return new DesignLayoutShell(shell);
            }
        }

        public LayoutShell GetRegionShell(RegionStyle region)
        {
            return new DesignLayoutShell(this.engine.GetShell(region));
        }

        #endregion クエリ

        #region コマンド

        public void Write()
        {
            this.engine.Write();
        }

        public void PostNodes(IEnumerable<Node> items)
        {
            this.engine.PostNodes(items);
        }

        public void DeleteNode(Node item)
        {
            this.engine.DeleteNode(item);
        }

        public void PostContents(IEnumerable<Content> items)
        {
            this.engine.PostContents(items);
        }

        public void DeleteContent(Content item)
        {
            this.engine.DeleteContent(item);
        }

        public void PostShells(IEnumerable<Shell> items)
        {
            this.engine.PostShells(items);
        }

        public void PostShell(Shell item)
        {
            this.engine.PostShell(item);
        }


        public void DeleteShell(Shell item)
        {
            this.engine.DeleteShell(item);
        }

        #endregion コマンド

        #endregion メソッド
    }
}
