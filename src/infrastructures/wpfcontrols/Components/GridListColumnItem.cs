using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components
{
    public class GridListColumnItem : GridViewColumn
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

        public static readonly DependencyProperty AttributeProperty =
            DependencyProperty.Register(nameof(Attribute), typeof(ColumnAttribute),
            typeof(GridListColumnItem),
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
        public GridListColumnItem()
        {
            
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
                var textBlock = new FrameworkElementFactory(typeof(TextBlock));
                textBlock.SetValue(TextBlock.TextProperty, ctrl.Item.Value.Value);
                var template = new DataTemplate();
                template.VisualTree = textBlock;
                ctrl.CellTemplate = template;
            }
        }

        /// <summary>
        /// アトリビュート変更時のイベント
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void OnAttributeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var ctrl = obj as GridListColumnItem;
            if (ctrl != null && ctrl.Attribute != null)
            {
                ctrl.Width = ctrl.Attribute.Width.Value;
                ctrl.Header = ctrl.Attribute.Header.Value;
            }
        }

        #endregion イベント

    }
}
