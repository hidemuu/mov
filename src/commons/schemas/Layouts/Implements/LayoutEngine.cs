﻿using Mov.Layouts.Contexts;
using Mov.Schemas.Resources.Keys;
using Mov.Schemas.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mov.Layouts.Implements
{
    public class LayoutEngine : ILayoutEngine
    {
        #region フィールド

        private readonly ILayoutContext context;

        #endregion フィールド

        #region プロパティ

        public CodeKey DomainId { get; }

        #endregion プロパティ

        #region コンストラクタ

        public LayoutEngine(ILayoutContext context)
        {
            this.context = context;
            this.DomainId = context.DomainId;
            this.Build(context);
        }

        #endregion コンストラクタ

        #region メソッド

        public void Build(ILayoutContext context)
        {
            this.SetNodeContents(context.Nodes);
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