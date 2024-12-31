using Mov.Core.Layouts.Models.Contents;
using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Models.Shells;
using Mov.Core.Layouts.Models.Themes;
using Mov.Core.Models;
using Mov.Core.Styles.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mov.Core.Layouts.Services
{
    public class LayoutEngine : ILayoutEngine
    {
        #region フィールド

        private readonly ILayoutContext context;

        #endregion フィールド

        #region プロパティ

        public Identifier<string> DomainId { get; }

        #endregion プロパティ

        #region コンストラクタ

        public LayoutEngine(ILayoutContext context)
        {
            this.context = context;
            DomainId = context.DomainId;
            Build(context);
        }

        #endregion コンストラクタ

        #region メソッド

        public void Build(ILayoutContext context)
        {
            SetNodeContents(context.Nodes);
        }

        public IEnumerable<LayoutNode> GetNodes()
        {
            return context.Nodes;
        }

        public LayoutNode GetRegionNode(RegionStyle region)
        {
            return context.Nodes.Where(x => x.NodeType.IsRegion).FirstOrDefault(x => x.Code.Value.Equals(region.Value));
        }

        public IEnumerable<LayoutContent> GetContents()
        {
            return context.Contents;
        }

        public IEnumerable<LayoutShell> GetShells()
        {
            return context.Shells;
        }

        public LayoutShell GetRegionShell(RegionStyle region)
        {
            return context.Shells.FirstOrDefault(x => x.Region.Equals(region));
        }

        public IEnumerable<LayoutTheme> GetThemes()
        {
            return context.Themes;
        }

        #endregion メソッド

        #region 内部メソッド

        private void SetNodeContents(IEnumerable<LayoutNode> nodes)
        {
            foreach (var node in nodes)
            {
                var content = context.Contents.FirstOrDefault(x => x.Keys.Code.Value.Equals(node.Code.Value));
                if (content != null) node.SetContent(content);
                SetNodeContents(node.Children);
            }
        }

        #endregion 内部メソッド
    }
}