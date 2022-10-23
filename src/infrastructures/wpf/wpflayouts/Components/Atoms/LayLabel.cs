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
    public class LayLabel : Label, ILayControl
    {
        static LayLabel()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayLabel), new FrameworkPropertyMetadata(typeof(LayLabel)));
        }

        public ILayoutContent LayoutContent
        {
            get { return (ILayoutContent)GetValue(LayoutContentProperty); }
            set { SetValue(LayoutContentProperty, value); }
        }

        public static readonly DependencyProperty LayoutContentProperty =
            DependencyProperty.Register(nameof(LayoutContent), typeof(ILayoutContent), typeof(LayLabel), new PropertyMetadata(default));

    }
}
