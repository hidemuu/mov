using Mov.Core.Layouts.Models.Nodes;
using Mov.Designer.Models.Entities;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Mov.Suite.DesignerClient.Wpf.Selectors
{
    public class LayoutContentSelector : DataTemplateSelector
    {
        #region method

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DesignerNode node)
            {
                FrameworkElementFactory factory;
                var controlType = node.Content.Keys.ControlType;

                if (controlType.IsLabel)
                {
                    return new DataTemplate() { VisualTree = CreateFactory<Label>(node), };
                }

                //どれにも該当しない場合、
                if (TryGetType(node.Content.Keys.ControlType.ToString(), out Type type))
                {
                    factory = new FrameworkElementFactory(type);
                    factory.SetValue(ContentControl.ContentProperty, node.Content.Statuses.Name.Value);
                    return new DataTemplate() { VisualTree = factory, };
                };
            }

            return base.SelectTemplate(item, container);
        }

        #endregion method

        #region inner method

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

        private FrameworkElementFactory GetDefault(LayoutNode node)
        {
            var defaultFactory = new FrameworkElementFactory(typeof(Label));
            defaultFactory.SetValue(ContentControl.ContentProperty, "【NotFound】" + node.ToString());
            return defaultFactory;
        }

        private FrameworkElementFactory CreateFactory<T>(LayoutNode node) where T : FrameworkElement
        {
            var factory = new FrameworkElementFactory(typeof(T));
            factory.SetValue(Label.ContentProperty, node.Content.Keys);
            return factory;
        }

        #endregion inner method
    }
}
