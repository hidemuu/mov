﻿using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfLayouts.Behaviors
{
    public class LayoutContentBehavior : Behavior<FrameworkElement>
    {
        #region イベント

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }

        //イベントハンドラ
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            //振る舞い
            var control = sender as ContentControl;
            
        }

        #endregion イベント
    }
}