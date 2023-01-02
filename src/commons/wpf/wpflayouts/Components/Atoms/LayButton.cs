using Mov.Layouts;
using Mov.Layouts.Contents.ValueObjects;
using Mov.Layouts.Contexts.Contents;
using Mov.WpfControls.Components.Atoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Mov.WpfLayouts.Components.Atoms
{
    public class LayButton : MovButton, ILayControl
    {
        static LayButton()
        {
            //デフォルトスタイルのメタデータを設定
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayButton), new FrameworkPropertyMetadata(typeof(LayButton)));
        }

        public LayoutContentKey LayoutKey
        {
            get { return (LayoutContentKey)GetValue(LayoutKeyProperty); }
            set { SetValue(LayoutKeyProperty, value); }
        }

        public static readonly DependencyProperty LayoutKeyProperty =
            DependencyProperty.Register(nameof(LayoutKey), typeof(LayoutContentKey), typeof(LayButton), new PropertyMetadata(default));

        public LayoutContentStatus LayoutParameter
        {
            get { return (LayoutContentStatus)GetValue(LayoutParameterProperty); }
            set { SetValue(LayoutParameterProperty, value); }
        }

        public static readonly DependencyProperty LayoutParameterProperty =
            DependencyProperty.Register(nameof(LayoutParameter), typeof(LayoutContentStatus), typeof(LayButton), new PropertyMetadata(default));


        public LayoutContentArrange LayoutDesign
        {
            get { return (LayoutContentArrange)GetValue(LayoutDesignProperty); }
            set { SetValue(LayoutDesignProperty, value); }
        }

        public static readonly DependencyProperty LayoutDesignProperty =
            DependencyProperty.Register(nameof(LayoutDesign), typeof(LayoutContentArrange), typeof(LayButton), new PropertyMetadata(default));

        public LayoutContentSchema LayoutValue
        {
            get { return (LayoutContentSchema)GetValue(LayoutValueProperty); }
            set { SetValue(LayoutValueProperty, value); }
        }

        public static readonly DependencyProperty LayoutValueProperty =
            DependencyProperty.Register(nameof(LayoutValue), typeof(LayoutContentSchema), typeof(LayButton), new PropertyMetadata(default));


    }
}
