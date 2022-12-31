using Mov.Designer.Models;
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
            if (item is LayoutNode node)
            {
                FrameworkElementFactory factory;
                var controlType = node.Content.LayoutKey.ControlType;
                if (controlType.IsLabel)
                {
                    factory = new FrameworkElementFactory(typeof(LayLabel));
                    factory.SetValue(LayLabel.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayLabel.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayLabel.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayLabel.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsButton)
                {
                    factory = new FrameworkElementFactory(typeof(LayButton));
                    factory.SetValue(LayButton.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayButton.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayButton.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayButton.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsRadioButton)
                {
                    factory = new FrameworkElementFactory(typeof(LayRadioButton));
                    factory.SetValue(LayRadioButton.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayRadioButton.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayRadioButton.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayRadioButton.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsTextBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayTextBox));
                    factory.SetValue(LayTextBox.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayTextBox.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayTextBox.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayTextBox.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsComboBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayComboBox));
                    factory.SetValue(LayComboBox.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayComboBox.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayComboBox.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayComboBox.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsSpinBox)
                {
                    factory = new FrameworkElementFactory(typeof(LaySpinBox));
                    factory.SetValue(LaySpinBox.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LaySpinBox.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LaySpinBox.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LaySpinBox.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsCheckBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayCheckBox));
                    factory.SetValue(LayCheckBox.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayCheckBox.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayCheckBox.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayCheckBox.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsListBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayListBox));
                    factory.SetValue(LayListBox.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayListBox.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayListBox.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayListBox.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsDatePicker)
                {
                    factory = new FrameworkElementFactory(typeof(LayDatePicker));
                    factory.SetValue(LayDatePicker.LayoutKeyProperty, node.Content.LayoutKey);
                    factory.SetValue(LayDatePicker.LayoutDesignProperty, node.Content.LayoutDesign);
                    factory.SetValue(LayDatePicker.LayoutParameterProperty, node.Content.LayoutParameter);
                    factory.SetValue(LayDatePicker.LayoutValueProperty, node.Content.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                
                //どれにも該当しない場合、
                if (TryGetType(node.Content.LayoutKey.ControlType.ToString(), out Type type))
                {
                    factory = new FrameworkElementFactory(type);
                    factory.SetValue(Label.ContentProperty, node.Content.LayoutParameter.Name.Value);
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

        private FrameworkElementFactory GetDefault(LayoutNode node)
        {
            var defaultFactory = new FrameworkElementFactory(typeof(Label));
            defaultFactory.SetValue(Label.ContentProperty, "【NotFound】" + node.ToString());
            return defaultFactory;
        }

        #endregion 内部メソッド
    }
}