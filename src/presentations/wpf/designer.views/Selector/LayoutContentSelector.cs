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
            if (item is DesignLayoutNode node)
            {
                FrameworkElementFactory factory;
                var controlType = node.LayoutKey.ControlType;
                if (controlType.IsLabel)
                {
                    factory = new FrameworkElementFactory(typeof(LayLabel));
                    factory.SetValue(LayLabel.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayLabel.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayLabel.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayLabel.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsButton)
                {
                    factory = new FrameworkElementFactory(typeof(LayButton));
                    factory.SetValue(LayButton.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayButton.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayButton.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayButton.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsRadioButton)
                {
                    factory = new FrameworkElementFactory(typeof(LayRadioButton));
                    factory.SetValue(LayRadioButton.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayRadioButton.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayRadioButton.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayRadioButton.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsTextBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayTextBox));
                    factory.SetValue(LayTextBox.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayTextBox.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayTextBox.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayTextBox.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsComboBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayComboBox));
                    factory.SetValue(LayComboBox.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayComboBox.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayComboBox.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayComboBox.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsSpinBox)
                {
                    factory = new FrameworkElementFactory(typeof(LaySpinBox));
                    factory.SetValue(LaySpinBox.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LaySpinBox.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LaySpinBox.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LaySpinBox.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsCheckBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayCheckBox));
                    factory.SetValue(LayCheckBox.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayCheckBox.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayCheckBox.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayCheckBox.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsListBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayListBox));
                    factory.SetValue(LayListBox.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayListBox.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayListBox.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayListBox.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsDatePicker)
                {
                    factory = new FrameworkElementFactory(typeof(LayDatePicker));
                    factory.SetValue(LayDatePicker.LayoutKeyProperty, node.LayoutKey);
                    factory.SetValue(LayDatePicker.LayoutDesignProperty, node.LayoutDesign);
                    factory.SetValue(LayDatePicker.LayoutParameterProperty, node.LayoutParameter);
                    factory.SetValue(LayDatePicker.LayoutValueProperty, node.LayoutValue);
                    return new DataTemplate() { VisualTree = factory, };
                }
                
                //どれにも該当しない場合、
                if (TryGetType(node.LayoutKey.ControlType.ToString(), out Type type))
                {
                    factory = new FrameworkElementFactory(type);
                    factory.SetValue(Label.ContentProperty, node.LayoutParameter.Name.Value);
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

        private FrameworkElementFactory GetDefault(DesignLayoutNode node)
        {
            var defaultFactory = new FrameworkElementFactory(typeof(Label));
            defaultFactory.SetValue(Label.ContentProperty, "【NotFound】" + node.ToString());
            return defaultFactory;
        }

        #endregion 内部メソッド
    }
}