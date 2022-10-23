using Mov.WpfModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Molecules
{
    public class ComGridViewColumn : GridViewColumn
    {

        #region プロパティ

        public static readonly DependencyProperty AttributeProperty =
            DependencyProperty.Register(nameof(Attribute), typeof(ColumnAttribute),
            typeof(ComGridViewColumn),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnAttributeChanged)));

        public ColumnAttribute Attribute
        {
            get { return (ColumnAttribute)GetValue(AttributeProperty); }
            set { SetValue(AttributeProperty, value); }
        }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ComGridViewColumn()
        {

        }

        #endregion コンストラクター

        #region イベント

        /// <summary>
        /// アトリビュート変更時のイベント
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnAttributeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as ComGridViewColumn;
            if (control != null)
            {
                if(control.Attribute != null)
                {
                    control.Width = control.Attribute.Width.Value;
                    control.Header = control.Attribute.Header.Value;
                }
            }
        }

        #endregion イベント

    }
}
