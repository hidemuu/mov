using Mov.Designer.Service.Layouts.Nodes;
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
    public class ContentSelector : DataTemplateSelector
    {
        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //var fileSystemInfo = (FileSystemInfo)item;
            //string templateKey = (fileSystemInfo.Attributes & FileAttributes.Directory) == FileAttributes.Directory
            //                    ? DirectoryTemplate
            //                    : FileTemplate;

            //return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate; 

            if (item is ContentLayoutNode node)
            {
                if (TryGetType(node.ControlType, out Type type))
                {
                    var factory = new FrameworkElementFactory(type);
                    return new DataTemplate() { VisualTree = factory, };
                };

                var defaultFactory = new FrameworkElementFactory(typeof(Label));
                defaultFactory.SetValue(Label.ContentProperty, "【NotFound】" + node.ToString());
                return new DataTemplate() { VisualTree = defaultFactory, };
            };
            return base.SelectTemplate(item, container);
        }

        #endregion メソッド

        #region 内部メソッド

        private bool TryGetType(string typeName, out Type type)
        {
            type = Type.GetType("System.Windows.Controls." + typeName);
            if (type != null) return true;
            return false;
        }

        #endregion メソッド
    }
}
