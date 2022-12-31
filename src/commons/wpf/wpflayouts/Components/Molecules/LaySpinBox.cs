using Mov.Layouts;
using Mov.Layouts.Contents;
using Mov.Layouts.Contents.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfLayouts.Components.Molecules
{
    public class LaySpinBox : Control, ILayControl
    {
        static LaySpinBox()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LaySpinBox), new FrameworkPropertyMetadata(typeof(LaySpinBox)));
        }

        public LayoutContentKey LayoutKey
        {
            get { return (LayoutContentKey)GetValue(LayoutKeyProperty); }
            set { SetValue(LayoutKeyProperty, value); }
        }

        public static readonly DependencyProperty LayoutKeyProperty =
            DependencyProperty.Register(nameof(LayoutKey), typeof(LayoutContentKey),
                typeof(LaySpinBox), new PropertyMetadata(default));

        public LayoutContentParameter LayoutParameter
        {
            get { return (LayoutContentParameter)GetValue(LayoutParameterProperty); }
            set { SetValue(LayoutParameterProperty, value); }
        }

        public static readonly DependencyProperty LayoutParameterProperty =
            DependencyProperty.Register(nameof(LayoutParameter), typeof(LayoutContentParameter),
                typeof(LaySpinBox), new PropertyMetadata(default));


        public LayoutContentDesign LayoutDesign
        {
            get { return (LayoutContentDesign)GetValue(LayoutDesignProperty); }
            set { SetValue(LayoutDesignProperty, value); }
        }

        public static readonly DependencyProperty LayoutDesignProperty =
            DependencyProperty.Register(nameof(LayoutDesign), typeof(LayoutContentDesign),
                typeof(LaySpinBox), new PropertyMetadata(default));

        public LayoutContentValue LayoutValue
        {
            get { return (LayoutContentValue)GetValue(LayoutValueProperty); }
            set { SetValue(LayoutValueProperty, value); }
        }

        public static readonly DependencyProperty LayoutValueProperty =
            DependencyProperty.Register(nameof(LayoutValue), typeof(LayoutContentValue),
                typeof(LaySpinBox), new PropertyMetadata(default));

    }
}
