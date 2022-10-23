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
    public class LayListBox : ListBox, ILayControl
    {
        static LayListBox()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayListBox), new FrameworkPropertyMetadata(typeof(LayListBox)));
        }

        public ILayoutContent LayoutContent
        {
            get { return (ILayoutContent)GetValue(LayoutContentProperty); }
            set { SetValue(LayoutContentProperty, value); }
        }

        public static readonly DependencyProperty LayoutContentProperty =
            DependencyProperty.Register(nameof(LayoutContent), typeof(ILayoutContent), typeof(LayListBox), new PropertyMetadata(default));

    }
}
