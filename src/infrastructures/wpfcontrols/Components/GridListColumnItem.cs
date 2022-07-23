using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components
{
    public class GridListColumnItem : TextBox
    {
        #region プロパティ

        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register(nameof(Item), typeof(ColumnItem),
            typeof(GridListColumnItem),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnItemChanged)));

        public ColumnItem Item
        {
            get { return (ColumnItem)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        #endregion プロパティ

        #region コンストラクター

        public GridListColumnItem()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        #endregion コンストラクター

        #region イベント

        /// <summary>
        /// アイテム変更時のイベント
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = obj as GridListColumnItem;
            if (ctrl != null && ctrl.Item != null)
            {
                ctrl.Text = ctrl.Item.Value.Value;
            }
        }

        #endregion イベント

    }
}
