using Mov.Designer.Service;
using Mov.Designer.Service.Nodes;
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
           
            if (item is ContentLayoutNode node)
            {
                if (TryGetType(node.ControlType, out Type type))
                {
                    var factory = new FrameworkElementFactory(type);
                    factory.SetValue(Label.ContentProperty, node.Name.Value);
                    return new DataTemplate() { VisualTree = factory, };
                };

                return new DataTemplate() { VisualTree = GetDefault(node), };
            };
            return base.SelectTemplate(item, container);
        }

        #endregion メソッド

        #region 内部メソッド

        private bool TryGetType(string typeName, out Type type)
        {
            if (string.IsNullOrEmpty(typeName)) 
            {
                type = null;
                return false;
            }
            string dllName = "System.Windows.Controls";
            string assemblyName = "PresentationFramework";
            type = Type.GetType(dllName + "." + typeName + ", " + assemblyName);
            if (type != null) return true;
            return false;
        }

        private FrameworkElementFactory GetDefault(ContentLayoutNode node)
        {
            var defaultFactory = new FrameworkElementFactory(typeof(Label));
            defaultFactory.SetValue(Label.ContentProperty, "【NotFound】" + node.ToString());
            return defaultFactory;
        }

        #endregion メソッド
    }
}
