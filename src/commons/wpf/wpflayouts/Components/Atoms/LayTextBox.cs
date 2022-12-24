using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
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

        public ILayoutKey LayoutKey
        {
            get { return (ILayoutKey)GetValue(LayoutKeyProperty); }
            set { SetValue(LayoutKeyProperty, value); }
        }

        public static readonly DependencyProperty LayoutKeyProperty =
            DependencyProperty.Register(nameof(LayoutKey), typeof(ILayoutKey),
                typeof(LayTextBox), new PropertyMetadata(default));

        public ILayoutParameter LayoutParameter
        {
            get { return (ILayoutParameter)GetValue(LayoutParameterProperty); }
            set { SetValue(LayoutParameterProperty, value); }
        }

        public static readonly DependencyProperty LayoutParameterProperty =
            DependencyProperty.Register(nameof(LayoutParameter), typeof(ILayoutParameter),
                typeof(LayTextBox), new PropertyMetadata(default));


        public ILayoutDesign LayoutDesign
        {
            get { return (ILayoutDesign)GetValue(LayoutDesignProperty); }
            set { SetValue(LayoutDesignProperty, value); }
        }

        public static readonly DependencyProperty LayoutDesignProperty =
            DependencyProperty.Register(nameof(LayoutDesign), typeof(ILayoutDesign),
                typeof(LayTextBox), new PropertyMetadata(default));

        public ILayoutValue LayoutValue
        {
            get { return (ILayoutValue)GetValue(LayoutValueProperty); }
            set { SetValue(LayoutValueProperty, value); }
        }

        public static readonly DependencyProperty LayoutValueProperty =
            DependencyProperty.Register(nameof(LayoutValue), typeof(ILayoutValue),
                typeof(LayTextBox), new PropertyMetadata(default));

    }
}
