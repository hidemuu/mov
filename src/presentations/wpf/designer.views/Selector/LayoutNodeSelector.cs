using Mov.Designer.Service.Layouts;
using Mov.Designer.Service.Layouts.Nodes;
using Mov.Designer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.Designer.Views.Selector
{
    public class LayoutNodeSelector : DataTemplateSelector
    {
        #region プロパティ

        public DataTemplate ExpanderTemplate { get; set; }

        public DataTemplate ScrollbarTemplate { get; set; }

        public DataTemplate TabTemplate { get; set; }

        public DataTemplate ContentTemplate { get; set; }

        public DataTemplate ViewTemplate { get; set; }


        #endregion プロパティ

        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is LayoutNodeBase node)
            {
                if (node is ContentLayoutNode content) return ContentTemplate;        
                if (node is ExpanderLayoutNode expander) return ExpanderTemplate;
                if (node is ScrollbarLayoutNode scrollbar) return ScrollbarTemplate;
                if (node is TabLayoutNode tab) return TabTemplate;
                return null;
            }
            return base.SelectTemplate(item, container);
        }

        #endregion メソッド
    }
}
