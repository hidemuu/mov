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

namespace Mov.WpfLayouts.Components.Atoms
{
    public class LayComboBox : ComboBox, ILayControl
    {
        static LayComboBox()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayComboBox), 
                new FrameworkPropertyMetadata(typeof(LayComboBox)));
        }

        public LayoutKey LayoutKey
        {
            get { return (LayoutKey)GetValue(LayoutKeyProperty); }
            set { SetValue(LayoutKeyProperty, value); }
        }

        public static readonly DependencyProperty LayoutKeyProperty =
            DependencyProperty.Register(nameof(LayoutKey), typeof(LayoutKey),
                typeof(LayComboBox), new PropertyMetadata(default));

        public LayoutParameter LayoutParameter
        {
            get { return (LayoutParameter)GetValue(LayoutParameterProperty); }
            set { SetValue(LayoutParameterProperty, value); }
        }

        public static readonly DependencyProperty LayoutParameterProperty =
            DependencyProperty.Register(nameof(LayoutParameter), typeof(LayoutParameter),
                typeof(LayComboBox), new PropertyMetadata(default));


        public LayoutDesign LayoutDesign
        {
            get { return (LayoutDesign)GetValue(LayoutDesignProperty); }
            set { SetValue(LayoutDesignProperty, value); }
        }

        public static readonly DependencyProperty LayoutDesignProperty =
            DependencyProperty.Register(nameof(LayoutDesign), typeof(LayoutDesign),
                typeof(LayComboBox), new PropertyMetadata(default));

        public LayoutValue LayoutValue
        {
            get { return (LayoutValue)GetValue(LayoutValueProperty); }
            set { SetValue(LayoutValueProperty, value); }
        }

        public static readonly DependencyProperty LayoutValueProperty =
            DependencyProperty.Register(nameof(LayoutValue), typeof(LayoutValue),
                typeof(LayComboBox), new PropertyMetadata(default));

    }
}
