using Mov.Designer.Models;
using Mov.Designer.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class DesignerService : IDesignerService
    {
        #region フィールド

        private readonly IDesignerEngine engine;

        #endregion フィールド

        #region プロパティ

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DesignerService(IDesignerEngine engine)
        {
            this.engine = engine;
        }

        #endregion コンストラクター

        #region メソッド

        #region UIモデル

        public IEnumerable<LayoutNodeBase> GetNodeModels()
        {
            return this.engine.Nodes;
        }

        public LayoutNodeBase GetNodeModel(RegionType type)
        {
            switch (type)
            {
                case RegionType.Center:
                    return this.engine.CenterNode;
                case RegionType.Top:
                    return this.engine.TopNode;
                case RegionType.Bottom:
                    return this.engine.BottomNode;
                case RegionType.Left:
                    return this.engine.LeftNode;
                case RegionType.Right:
                    return this.engine.RightNode;
            }
            return this.engine.CenterNode;
        }

        #endregion UIモデル

        #region クエリ

        public void Read()
        {
            this.engine.Query.LayoutNode.Read();
            this.engine.Query.LayoutContent.Read();
            this.engine.Query.Shell.Read();
        }

        public IEnumerable<LayoutNode> GetNodes()
        {
            return this.engine.Query.LayoutNode.Gets();
        }

        public LayoutNode GetNode(Guid id)
        {
            return this.engine.Query.LayoutNode.Get(id);
        }

        public LayoutNode GetNode(string code)
        {
            return this.engine.Query.LayoutNode.Get(code);
        }


        public IEnumerable<LayoutContent> GetContents()
        {
            return this.engine.Query.LayoutContent.Gets();
        }

        public LayoutContent GetContent(Guid id)
        {
            return this.engine.Query.LayoutContent.Get(id);
        }

        public LayoutContent GetContent(string code)
        {
            return this.engine.Query.LayoutContent.Get(code);
        }

        public IEnumerable<Shell> GetShells()
        {
            return this.engine.Query.Shell.Gets();
        }

        public Shell GetShell(RegionType type)
        {
            return this.engine.Query.Shell.Get(type.ToString());
        }

        #endregion クエリ

        #region コマンド

        public void Write()
        {
            this.engine.Command.LayoutNode.Write();
            this.engine.Command.LayoutContent.Write();
            this.engine.Command.Shell.Write();
        }

        public void PostNodes(IEnumerable<LayoutNode> items)
        {
            this.engine.Command.LayoutNode.Posts(items);
        }

        public void PostNode(LayoutNode item)
        {
            this.engine.Command.LayoutNode.Post(item);
        }

        public void PutNode(LayoutNode item)
        {
            this.engine.Command.LayoutNode.Put(item);
        }

        public void DeleteNode(LayoutNode item)
        {
            this.engine.Command.LayoutNode.Delete(item);
        }

        public void PostContents(IEnumerable<LayoutContent> items)
        {
            this.engine.Command.LayoutContent.Posts(items);
        }

        public void PostContent(LayoutContent item)
        {
            this.engine.Command.LayoutContent.Post(item);
        }

        public void PutContent(LayoutContent item)
        {
            this.engine.Command.LayoutContent.Put(item);
        }

        public void DeleteContent(LayoutContent item)
        {
            this.engine.Command.LayoutContent.Delete(item);
        }

        public void PostShells(IEnumerable<Shell> items)
        {
            this.engine.Command.Shell.Posts(items);
        }

        public void PostShell(Shell item)
        {
            this.engine.Command.Shell.Post(item);
        }

        public void PutShell(Shell item)
        {
            this.engine.Command.Shell.Put(item);
        }

        public void DeleteShell(Shell item)
        {
            this.engine.Command.Shell.Delete(item);
        }

        #endregion コマンド

        #endregion メソッド
    }
}
