using Mov.Designer.Service.Nodes;
using Mov.WpfLayouts.Components;
using Mov.WpfLayouts.Components.Atoms;
using Mov.WpfLayouts.Components.Molecules;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Mov.Designer.Views.Selector
{
    public class LayoutContentSelector : DataTemplateSelector
    {
        
        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ContentLayoutNode node)
            {
                FrameworkElementFactory factory;
                switch (node.Content.ControlType)
                {
                    case Models.ControlType.Label:
                        factory = new FrameworkElementFactory(typeof(LayLabel));
                        factory.SetValue(LayLabel.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.Button:
                        factory = new FrameworkElementFactory(typeof(LayButton));
                        factory.SetValue(LayButton.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.RadioButton:
                        factory = new FrameworkElementFactory(typeof(LayRadioButton));
                        factory.SetValue(LayRadioButton.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.TextBox:
                        factory = new FrameworkElementFactory(typeof(LayTextBox));
                        factory.SetValue(LayTextBox.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.ComboBox:
                        factory = new FrameworkElementFactory(typeof(LayComboBox));
                        factory.SetValue(LayComboBox.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.SpinBox:
                        factory = new FrameworkElementFactory(typeof(LaySpinBox));
                        factory.SetValue(LaySpinBox.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.CheckBox:
                        factory = new FrameworkElementFactory(typeof(LayCheckBox));
                        factory.SetValue(LayCheckBox.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.ListBox:
                        factory = new FrameworkElementFactory(typeof(LayListBox));
                        factory.SetValue(LayListBox.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                    case Models.ControlType.DatePicker:
                        factory = new FrameworkElementFactory(typeof(LayDatePicker));
                        factory.SetValue(LayDatePicker.LayoutContentProperty, node.Content);
                        return new DataTemplate() { VisualTree = factory, };
                }
                //どれにも該当しない場合、
                if (TryGetType(node.Content.ControlType.ToString(), out Type type))
                {
                    factory = new FrameworkElementFactory(type);
                    factory.SetValue(Label.ContentProperty, node.Content.Name);
                    return new DataTemplate() { VisualTree = factory, };
                };

                return new DataTemplate() { VisualTree = GetDefault(node), };
            }
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

        #endregion 内部メソッド
    }
}