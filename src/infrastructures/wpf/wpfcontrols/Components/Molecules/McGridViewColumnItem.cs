using Mov.WpfModels;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Molecules
{
    public class McGridViewColumnItem : TextBox
    {

        #region プロパティ

        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register(nameof(Item), typeof(ColumnItem),
            typeof(McGridViewColumnItem),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnItemChanged)));

        public ColumnItem Item
        {
            get { return (ColumnItem)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        #endregion プロパティ

        #region コマンド

        #endregion コマンド

        #region コンストラクター

        public McGridViewColumnItem()
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
            TextChanged += OnTextChanged;
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
            var ctrl = obj as McGridViewColumnItem;
            if (ctrl != null && ctrl.Item != null)
            {
                ctrl.Text = ctrl.Item.ToString();
            }
        }

        /// <summary>
        /// テキスト変更時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if(sender is McGridViewColumnItem item && item != null)
            {
                Item.SetValue(item.Text);
            }
        }

        #endregion イベント

    }
}
