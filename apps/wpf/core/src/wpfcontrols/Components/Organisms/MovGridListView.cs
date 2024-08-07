﻿using Mov.WpfControls.Components.Molecules;
using Mov.WpfModels.Controls;
using Reactive.Bindings;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components.Organisms
{
    /// <summary>
    /// グリッド型のリストビュー
    /// </summary>
    public class MovGridListView : ListView
    {
        static MovGridListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovGridListView), new FrameworkPropertyMetadata(typeof(MovGridListView)));
        }

        #region プロパティ

        public ReactiveCollection<ColumnItem[]> ColumnItems
        {
            get { return (ReactiveCollection<ColumnItem[]>)GetValue(ColumnItemsProperty); }
            set { SetValue(ColumnItemsProperty, value); }
        }

        public static readonly DependencyProperty ColumnItemsProperty =
            DependencyProperty.Register(nameof(ColumnItems), typeof(ReactiveCollection<ColumnItem[]>),
            typeof(MovGridListView),
            new UIPropertyMetadata(null));

        public ColumnItem[] SelectedColumnItem
        {
            get { return (ColumnItem[])GetValue(SelectedColumnItemProperty); }
            set { SetValue(SelectedColumnItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedColumnItemProperty =
            DependencyProperty.Register(nameof(SelectedColumnItem), typeof(ColumnItem[]),
            typeof(MovGridListView),
            new UIPropertyMetadata(null));

        public ColumnAttribute[] ColumnAttributes
        {
            get { return (ColumnAttribute[])GetValue(ColumnAttributesProperty); }
            set { SetValue(ColumnAttributesProperty, value); }
        }

        public static readonly DependencyProperty ColumnAttributesProperty =
            DependencyProperty.Register(nameof(ColumnAttributes), typeof(ColumnAttribute[]),
            typeof(MovGridListView),
            new UIPropertyMetadata(null));

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public MovGridListView()
        {
            ItemsSource = ColumnItems;
            SelectedItem = SelectedColumnItem;
            var gridView = new GridView();
            //列
            for (var columnCount = 0; columnCount < ColumnAttributes.Length; columnCount++)
            {
                var column = new MovGridViewColumn();
                column.Attribute = ColumnAttributes[columnCount];
                var dataTemplate = new DataTemplate();
                var columnItem = new FrameworkElementFactory(typeof(MovGridViewColumnItem));
                columnItem.SetValue(MovGridViewColumnItem.ItemProperty, Items[columnCount]);
                dataTemplate.VisualTree = columnItem;
                column.CellTemplate = dataTemplate;
                gridView.Columns.Add(column);
            }
            //行

            View = gridView;
        }

        #endregion コンストラクター

        #region メソッド

        #endregion メソッド

    }
}
