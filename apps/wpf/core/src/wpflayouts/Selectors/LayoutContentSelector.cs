using Mov.Core.Layouts.Models.Nodes;
using Mov.WpfLayouts.Components.Atoms;
using Mov.WpfLayouts.Components.Molecules;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfLayouts.Selectors
{
    public class LayoutContentSelector : DataTemplateSelector
    {
        #region メソッド

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is LayoutNode node)
            {
                FrameworkElementFactory factory;
                var controlType = node.Content.Keys.ControlType;
                if (controlType.IsLabel)
                {
                    return new DataTemplate() { VisualTree = CreateFactory<LayLabel>(node), };
                }
                if (controlType.IsButton)
                {
                    factory = new FrameworkElementFactory(typeof(LayButton));
                    factory.SetValue(LayButton.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayButton.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayButton.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayButton.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsRadioButton)
                {
                    factory = new FrameworkElementFactory(typeof(LayRadioButton));
                    factory.SetValue(LayRadioButton.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayRadioButton.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayRadioButton.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayRadioButton.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsTextBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayTextBox));
                    factory.SetValue(LayTextBox.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayTextBox.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayTextBox.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayTextBox.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsComboBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayComboBox));
                    factory.SetValue(LayComboBox.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayComboBox.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayComboBox.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayComboBox.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsSpinBox)
                {
                    factory = new FrameworkElementFactory(typeof(LaySpinBox));
                    factory.SetValue(LaySpinBox.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LaySpinBox.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LaySpinBox.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LaySpinBox.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsCheckBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayCheckBox));
                    factory.SetValue(LayCheckBox.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayCheckBox.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayCheckBox.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayCheckBox.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsListBox)
                {
                    factory = new FrameworkElementFactory(typeof(LayListBox));
                    factory.SetValue(LayListBox.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayListBox.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayListBox.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayListBox.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }
                if (controlType.IsDatePicker)
                {
                    factory = new FrameworkElementFactory(typeof(LayDatePicker));
                    factory.SetValue(LayDatePicker.LayoutKeyProperty, node.Content.Keys);
                    factory.SetValue(LayDatePicker.LayoutDesignProperty, node.Content.Arranges);
                    factory.SetValue(LayDatePicker.LayoutParameterProperty, node.Content.Statuses);
                    factory.SetValue(LayDatePicker.LayoutValueProperty, node.Content.Schemas);
                    return new DataTemplate() { VisualTree = factory, };
                }

                //どれにも該当しない場合、
                if (TryGetType(node.Content.Keys.ControlType.ToString(), out Type type))
                {
                    factory = new FrameworkElementFactory(type);
                    factory.SetValue(ContentControl.ContentProperty, node.Content.Statuses.Name.Value);
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
            defaultFactory.SetValue(ContentControl.ContentProperty, "【NotFound】" + node.ToString());
            return defaultFactory;
        }

        private FrameworkElementFactory CreateFactory<T>(LayoutNode node) where T : FrameworkElement
        {
            var factory = new FrameworkElementFactory(typeof(T));
            factory.SetValue(LayLabel.LayoutKeyProperty, node.Content.Keys);
            factory.SetValue(LayLabel.LayoutDesignProperty, node.Content.Arranges);
            factory.SetValue(LayLabel.LayoutParameterProperty, node.Content.Statuses);
            factory.SetValue(LayLabel.LayoutValueProperty, node.Content.Schemas);
            return factory;
        }

        #endregion 内部メソッド
    }
}