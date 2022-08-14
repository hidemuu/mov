using Mov.Designer.Service;
using Mov.Designer.Service.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.Designer.Views.Selector
{
    public class LayoutContentSelector : DataTemplateSelector
    {
        #region プロパティ

        public DataTemplate LabelTemplate { get; set; }

        public DataTemplate ButtonTemplate { get; set; }

        public DataTemplate RadioButtonTemplate { get; set; }

        public DataTemplate TextBoxTemplate { get; set; }

        public DataTemplate ComboBoxTemplate { get; set; }

        public DataTemplate SpinBoxTemplate { get; set; }

        public DataTemplate CheckBoxTemplate { get; set; }

        public DataTemplate ListBoxTemplate { get; set; }

        public DataTemplate DatePickerTemplate { get; set; }

        #endregion プロパティ

        #region メソッド
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is ContentLayoutNode node)
            {
                switch (node.ControlType) 
                {
                    case Models.ControlType.Label:
                        return LabelTemplate;
                    case Models.ControlType.Button:
                        return ButtonTemplate;
                    case Models.ControlType.RadioButton:
                        return RadioButtonTemplate;
                    case Models.ControlType.TextBox:
                        return TextBoxTemplate;
                    case Models.ControlType.ComboBox:
                        return ComboBoxTemplate;
                    case Models.ControlType.SpinBox:
                        return SpinBoxTemplate;
                    case Models.ControlType.CheckBox:
                        return CheckBoxTemplate;
                    case Models.ControlType.ListBox:
                        return ListBoxTemplate;
                    case Models.ControlType.DatePicker:
                        return DatePickerTemplate;
                }
                //どれにも該当しない場合、
                if (TryGetType(node.ControlType.ToString(), out Type type))
                {
                    var factory = new FrameworkElementFactory(type);
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
