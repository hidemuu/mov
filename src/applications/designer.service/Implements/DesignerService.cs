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

        public LayoutNodeBase GetNodeModel(LocationType type)
        {
            switch (type)
            {
                case LocationType.Center:
                    return this.engine.CenterNode;
                case LocationType.Top:
                    return this.engine.TopNode;
                case LocationType.Bottom:
                    return this.engine.BottomNode;
                case LocationType.Left:
                    return this.engine.LeftNode;
                case LocationType.Right:
                    return this.engine.RightNode;
            }
            return this.engine.CenterNode;
        }

        #endregion UIモデル

        #region クエリ

        public IEnumerable<LayoutNode> GetNodes()
        {
            return this.engine.Query.LayoutNode.Gets();
        }

        public IEnumerable<LayoutContent> GetContents()
        {
            return this.engine.Query.LayoutContent.Gets();
        }

        public LayoutNode GetNode(Guid id)
        {
            return this.engine.Query.LayoutNode.Get(id);
        }

        public LayoutContent GetContent(Guid id)
        {
            return this.engine.Query.LayoutContent.Get(id);
        }

        public LayoutNode GetNode(string code)
        {
            return this.engine.Query.LayoutNode.Get(code);
        }

        public LayoutContent GetContent(string code)
        {
            return this.engine.Query.LayoutContent.Get(code);
        }

        public Shell GetShell(LocationType type)
        {
            return this.engine.Query.Shell.Get(type.ToString());
        }

        #endregion クエリ

        #region コマンド

        public void Write()
        {
            this.engine.Command.LayoutNode.Write();
            this.engine.Command.LayoutContent.Write();
        }

        public void PostNodes(IEnumerable<LayoutNode> items)
        {
            this.engine.Command.LayoutNode.Posts(items);
        }

        public void PostContents(IEnumerable<LayoutContent> items)
        {
            this.engine.Command.LayoutContent.Posts(items);
        }

        public void PostNode(LayoutNode item)
        {
            this.engine.Command.LayoutNode.Post(item);
        }

        public void PostContent(LayoutContent item)
        {
            this.engine.Command.LayoutContent.Post(item);
        }

        public void PutNode(LayoutNode item)
        {
            this.engine.Command.LayoutNode.Put(item);
        }

        public void PutContent(LayoutContent item)
        {
            this.engine.Command.LayoutContent.Put(item);
        }

        public void DeleteNode(LayoutNode item)
        {
            this.engine.Command.LayoutNode.Delete(item);
        }

        public void DeleteContent(LayoutContent item)
        {
            this.engine.Command.LayoutContent.Delete(item);
        }

        #endregion コマンド

        #endregion メソッド
    }
}
