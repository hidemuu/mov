using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components
{
    public class GridListColumn : GridViewColumn
    {

        #region プロパティ

        public static readonly DependencyProperty AttributeProperty =
            DependencyProperty.Register(nameof(Attribute), typeof(ColumnAttribute),
            typeof(GridListColumn),
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
        public GridListColumn()
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
            var ctrl = obj as GridListColumn;
            if (ctrl != null && ctrl.Attribute != null)
            {
                ctrl.Width = ctrl.Attribute.Width.Value;
                ctrl.Header = ctrl.Attribute.Header.Value;
            }
        }

        #endregion イベント

    }
}
