using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovButton : Button
    {
        static MovButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovButton), new FrameworkPropertyMetadata(typeof(MovButton)));
        }

        #region プロパティ

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(MovButton), new PropertyMetadata(default));

        #endregion プロパティ

    }
}
