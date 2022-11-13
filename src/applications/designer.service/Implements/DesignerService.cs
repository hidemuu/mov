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
            this.engine.Repository.Nodes.Read();
            this.engine.Repository.Contents.Read();
            this.engine.Repository.Shells.Read();
        }

        public IEnumerable<LayoutNode> GetNodes()
        {
            return this.engine.Repository.Nodes.Get();
        }

        public LayoutNode GetNode(Guid id)
        {
            return this.engine.Repository.Nodes.Get(id);
        }

        public LayoutNode GetNode(string code)
        {
            return this.engine.Repository.Nodes.Get(code);
        }


        public IEnumerable<LayoutContent> GetContents()
        {
            return this.engine.Repository.Contents.Get();
        }

        public LayoutContent GetContent(Guid id)
        {
            return this.engine.Repository.Contents.Get(id);
        }

        public LayoutContent GetContent(string code)
        {
            return this.engine.Repository.Contents.Get(code);
        }

        public IEnumerable<Shell> GetShells()
        {
            return this.engine.Repository.Shells.Get();
        }

        public Shell GetShell(RegionType type)
        {
            return this.engine.Repository.Shells.Get(type.ToString());
        }

        #endregion クエリ

        #region コマンド

        public void Write()
        {
            this.engine.Repository.Nodes.Write();
            this.engine.Repository.Contents.Write();
            this.engine.Repository.Shells.Write();
        }

        public void PostNodes(IEnumerable<LayoutNode> items)
        {
            this.engine.Repository.Nodes.Posts(items);
        }

        public void PostNode(LayoutNode item)
        {
            this.engine.Repository.Nodes.Post(item);
        }

        public void PutNode(LayoutNode item)
        {
            this.engine.Repository.Nodes.Put(item);
        }

        public void DeleteNode(LayoutNode item)
        {
            this.engine.Repository.Nodes.Delete(item);
        }

        public void PostContents(IEnumerable<LayoutContent> items)
        {
            this.engine.Repository.Contents.Posts(items);
        }

        public void PostContent(LayoutContent item)
        {
            this.engine.Repository.Contents.Post(item);
        }

        public void PutContent(LayoutContent item)
        {
            this.engine.Repository.Contents.Put(item);
        }

        public void DeleteContent(LayoutContent item)
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

        public void PutShell(Shell item)
        {
            this.engine.Repository.Shells.Put(item);
        }

        public void DeleteShell(Shell item)
        {
            this.engine.Repository.Shells.Delete(item);
        }

        #endregion コマンド

        #endregion メソッド
    }
}
