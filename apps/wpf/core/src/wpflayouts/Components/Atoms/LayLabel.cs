﻿using Mov.Core.Layouts.Models.Contents;
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

        public LayoutContentKey LayoutKey
        {
            get { return (LayoutContentKey)GetValue(LayoutKeyProperty); }
            set { SetValue(LayoutKeyProperty, value); }
        }

        public static readonly DependencyProperty LayoutKeyProperty =
            DependencyProperty.Register(nameof(LayoutKey), typeof(LayoutContentKey),
                typeof(LayLabel), new PropertyMetadata(default));

        public LayoutContentStatus LayoutParameter
        {
            get { return (LayoutContentStatus)GetValue(LayoutParameterProperty); }
            set { SetValue(LayoutParameterProperty, value); }
        }

        public static readonly DependencyProperty LayoutParameterProperty =
            DependencyProperty.Register(nameof(LayoutParameter), typeof(LayoutContentStatus),
                typeof(LayLabel), new PropertyMetadata(default));

        public LayoutContentArrange LayoutDesign
        {
            get { return (LayoutContentArrange)GetValue(LayoutDesignProperty); }
            set { SetValue(LayoutDesignProperty, value); }
        }

        public static readonly DependencyProperty LayoutDesignProperty =
            DependencyProperty.Register(nameof(LayoutDesign), typeof(LayoutContentArrange),
                typeof(LayLabel), new PropertyMetadata(default));

        public LayoutContentValue LayoutValue
        {
            get { return (LayoutContentValue)GetValue(LayoutValueProperty); }
            set { SetValue(LayoutValueProperty, value); }
        }

        public static readonly DependencyProperty LayoutValueProperty =
            DependencyProperty.Register(nameof(LayoutValue), typeof(LayoutContentValue),
                typeof(LayLabel), new PropertyMetadata(default));
    }
}