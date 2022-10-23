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
    public class LayTextBox : TextBox, ILayControl
    {
        static LayTextBox()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayTextBox), new FrameworkPropertyMetadata(typeof(LayTextBox)));
        }

        public ILayoutContent LayoutContent
        {
            get { return (ILayoutContent)GetValue(LayoutContentProperty); }
            set { SetValue(LayoutContentProperty, value); }
        }

        public static readonly DependencyProperty LayoutContentProperty =
            DependencyProperty.Register(nameof(LayoutContent), typeof(ILayoutContent), typeof(LayTextBox), new PropertyMetadata(default));

    }
}
