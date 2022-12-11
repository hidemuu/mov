using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using Mov.Layouts;
using Mov.Layouts.ValueObjects;
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
            this.engine = engines.First();
        }

        #endregion コンストラクター

        #region メソッド

        #region UIモデル

        public LayoutNode GetNodeModel(ShellRegion region)
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
            return this.engine.Repository.Nodes.Get();
        }

        public Node GetNode(Guid id)
        {
            return this.engine.Repository.Nodes.Get(id);
        }

        public IEnumerable<Content> GetContents()
        {
            return this.engine.Repository.Contents.Get();
        }

        public Content GetContent(Guid id)
        {
            return this.engine.Repository.Contents.Get(id);
        }

        public Content GetContent(string code)
        {
            return this.engine.Repository.Contents.Get(code);
        }

        public IEnumerable<Shell> GetShells()
        {
            return this.engine.Repository.Shells.Get();
        }

        public Shell GetShell(ShellRegion region)
        {
            return this.engine.Repository.Shells.Get(region.Value);
        }

        #endregion クエリ

        #region コマンド

        public void Write()
        {
            this.engine.Write();
        }

        public void PostNodes(IEnumerable<Node> items)
        {
            this.engine.Repository.Nodes.Posts(items);
        }

        public void DeleteNode(Node item)
        {
            this.engine.Repository.Nodes.Delete(item);
        }

        public void PostContents(IEnumerable<Content> items)
        {
            this.engine.Repository.Contents.Posts(items);
        }

        public void DeleteContent(Content item)
        {
            this.engine.Repository.Contents.Delete(item);
        }

        public void PostShells(IEnumerable<Shell> items)
        {
            this.engine.Repository.Shells.Posts(items);
        }

        public void PostShell(Shell item)
        {
            this.engine.Repository.Shells.Post(item);
        }


        public void DeleteShell(Shell item)
        {
            this.engine.Repository.Shells.Delete(item);
        }

        #endregion コマンド

        #endregion メソッド
    }
}
