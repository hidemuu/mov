using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mov.WpfControls.Components
{
    /// <summary>
    /// GridListControl.xaml の相互作用ロジック
    /// </summary>
    public partial class GridListControl : UserControl
    {
        #region プロパティ

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(nameof(Items), typeof(ReactiveCollection<ColumnItem[]>),
            typeof(GridListControl),
            new UIPropertyMetadata(null));

        public ReactiveCollection<ColumnItem[]> Items
        {
            get { return (ReactiveCollection<ColumnItem[]>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(ColumnItem[]),
            typeof(GridListControl),
            new UIPropertyMetadata(null));

        public ColumnItem[] SelectedItem
        {
            get { return (ColumnItem[])GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty AttributesProperty =
            DependencyProperty.Register(nameof(Attributes), typeof(ColumnAttribute[]),
            typeof(GridListControl),
            new UIPropertyMetadata(null));

        public ColumnAttribute[] Attributes
        {
            get { return (ColumnAttribute[])GetValue(AttributesProperty); }
            set { SetValue(AttributesProperty, value); }
        }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public GridListControl()
        {
            InitializeComponent();
        }

        #endregion コンストラクター
    }
}
