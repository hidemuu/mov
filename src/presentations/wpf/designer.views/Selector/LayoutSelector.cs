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
    internal class LayoutSelector : DataTemplateSelector
    {
        #region プロパティ

        public DataTemplate ExpanderTemplate { get; set; }

        public DataTemplate ScrollbarTemplate { get; set; }

        public DataTemplate TabTemplate { get; set; }

        public DataTemplate HeaderTemplate { get; set; }

        public DataTemplate ContentTemplate { get; set; }

        #endregion プロパティ

        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var fileSystemInfo = (FileSystemInfo)item;
            //string templateKey = (fileSystemInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory
            //                    ? DirectoryTemplate
            //                    : FileTemplate;

            //return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate;
            if(item is DesignerPartsViewModel vm)
            {
                
            }
            return null;
        }

        #endregion メソッド
    }
}
