using Mov.Designer.Service;
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

        public DataTemplate ComboBoxTemplate { get; set; }

        public DataTemplate SpinBoxTemplate { get; set; }

        public DataTemplate CheckBoxTemplate { get; set; }

        #endregion プロパティ

        #region メソッド
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is LayoutBase node)
            {
                switch (node.ControlType) 
                {
                    case Models.ControlType.Label:
                        return LabelTemplate;
                    case Models.ControlType.ComboBox:
                        return ComboBoxTemplate;
                    case Models.ControlType.SpinBox:
                        return SpinBoxTemplate;
                    case Models.ControlType.CheckBox:
                        return CheckBoxTemplate;
                }
                return null;
            }
            return base.SelectTemplate(item, container);
        }

        #endregion メソッド
    }
}
