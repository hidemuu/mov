using Mov.Layouts.Models.Entities;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfLayouts.Selector
{
    public class LayoutNodeSelector : DataTemplateSelector
    {
        #region プロパティ

        public DataTemplate ExpanderTemplate { get; set; }

        public DataTemplate GroupTemplate { get; set; }

        public DataTemplate ScrollbarTemplate { get; set; }

        public DataTemplate TabTemplate { get; set; }

        public DataTemplate ContentTemplate { get; set; }

        public DataTemplate ViewTemplate { get; set; }

        public DataTemplate TreeTemplate { get; set; }

        public DataTemplate TableTemplate { get; set; }

        #endregion プロパティ

        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is LayoutNode node)
            {
                if (node.NodeType.IsRegion) return GroupTemplate;
                if (node.NodeType.IsContent) return ContentTemplate;
                if (node.NodeType.IsExpander) return ExpanderTemplate;
                if (node.NodeType.IsGroup) return GroupTemplate;
                if (node.NodeType.IsScroll) return ScrollbarTemplate;
                if (node.NodeType.IsTab) return TabTemplate;
                if (node.NodeType.IsTable) return TableTemplate;
                if (node.NodeType.IsTree) return TreeTemplate;
                return null;
            }
            return base.SelectTemplate(item, container);
        }

        #endregion メソッド
    }
}