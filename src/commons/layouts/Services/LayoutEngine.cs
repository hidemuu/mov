using Mov.Layouts.Contexts;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mov.Layouts.Services
{
    public class LayoutEngine : ILayoutEngine
    {
        #region フィールド

        private readonly LayoutContext context;

        #endregion フィールド

        #region プロパティ

        public int DomainId { get; }

        #endregion プロパティ

        #region コンストラクタ

        public LayoutEngine(int domainId, LayoutContext context)
        {
            this.DomainId = domainId;
            this.context = context;
            this.Build();
        }

        #endregion コンストラクタ

        #region メソッド

        public void Build()
        {
            CreateNode(this.context.Nodes);
        }

        public IEnumerable<LayoutNode> GetNodes()
        {
            return this.context.Nodes;
        }

        public LayoutNode GetRegionNode(RegionStyle region)
        {
            return this.context.Nodes.Where(x => x.NodeType.IsRegion).FirstOrDefault(x => x.Content.Keys.Code.Equals(region.Value));
        }

        public IEnumerable<LayoutContent> GetContents()
        {
            return this.context.Contents;
        }

        public IEnumerable<LayoutShell> GetShells()
        {
            return this.context.Shells;
        }


        public LayoutShell GetRegionShell(RegionStyle region)
        {
            return this.context.Shells.FirstOrDefault(x => x.Region.Equals(region));
        }

        public IEnumerable<LayoutTheme> GetThemes()
        {
            return this.context.Themes;
        }

        #endregion メソッド

        #region 内部メソッド

        private void CreateNode(IEnumerable<LayoutNode> nodes)
        {
            foreach(var node in nodes)
            {
                var content = this.context.Contents.FirstOrDefault(x => x.Keys.Code.Equals(node.Code));
                if (content != null) node.SetContent(content);
                CreateNode(node.Children);
            }
        }

        #endregion 内部メソッド
    }
}
