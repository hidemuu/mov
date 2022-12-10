using Mov.Designer.Models.Nodes;
using Mov.Layouts;
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
                switch (node.ControlType.Value)
                {
                    case ControlType.Label:
                        factory = new FrameworkElementFactory(typeof(LayLabel));
                        factory.SetValue(LayLabel.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.Button:
                        factory = new FrameworkElementFactory(typeof(LayButton));
                        factory.SetValue(LayButton.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.RadioButton:
                        factory = new FrameworkElementFactory(typeof(LayRadioButton));
                        factory.SetValue(LayRadioButton.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.TextBox:
                        factory = new FrameworkElementFactory(typeof(LayTextBox));
                        factory.SetValue(LayTextBox.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.ComboBox:
                        factory = new FrameworkElementFactory(typeof(LayComboBox));
                        factory.SetValue(LayComboBox.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.SpinBox:
                        factory = new FrameworkElementFactory(typeof(LaySpinBox));
                        factory.SetValue(LaySpinBox.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.CheckBox:
                        factory = new FrameworkElementFactory(typeof(LayCheckBox));
                        factory.SetValue(LayCheckBox.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.ListBox:
                        factory = new FrameworkElementFactory(typeof(LayListBox));
                        factory.SetValue(LayListBox.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                    case ControlType.DatePicker:
                        factory = new FrameworkElementFactory(typeof(LayDatePicker));
                        factory.SetValue(LayDatePicker.LayoutContentProperty, node);
                        return new DataTemplate() { VisualTree = factory, };
                }
                //どれにも該当しない場合、
                if (TryGetType(node.ControlType.ToString(), out Type type))
                {
                    factory = new FrameworkElementFactory(type);
                    factory.SetValue(Label.ContentProperty, node.Name);
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