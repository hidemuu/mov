using Mov.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfLayouts.Components.Atoms
{
    public class LayRadioButton : RadioButton, ILayControl
    {
        static LayRadioButton()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayRadioButton), new FrameworkPropertyMetadata(typeof(LayRadioButton)));
        }

        public ILayoutContent LayoutContent
        {
            get { return (ILayoutContent)GetValue(LayoutContentProperty); }
            set { SetValue(LayoutContentProperty, value); }
        }

        public static readonly DependencyProperty LayoutContentProperty =
            DependencyProperty.Register(nameof(LayoutContent), typeof(ILayoutContent), typeof(LayRadioButton), new PropertyMetadata(default));

    }
}
