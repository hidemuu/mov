using Mov.WpfModels.Controls;
using Reactive.Bindings;
using System.Windows;
using System.Windows.Controls;

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
            DependencyProperty.Register(nameof(SelectedItem), typeof(ReactivePropertySlim<ColumnItem[]>),
            typeof(GridListControl),
            new UIPropertyMetadata(null));

        public ReactivePropertySlim<ColumnItem[]> SelectedItem
        {
            get { return (ReactivePropertySlim<ColumnItem[]>)GetValue(SelectedItemProperty); }
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

        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register(nameof(AddCommand), typeof(ReactiveCommand<object>),
            typeof(GridListControl),
            new UIPropertyMetadata(null));

        public ReactiveCommand<object> AddCommand
        {
            get { return (ReactiveCommand<object>)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        public static readonly DependencyProperty DeleteCommandProperty =
            DependencyProperty.Register(nameof(DeleteCommand), typeof(ReactiveCommand<object>),
            typeof(GridListControl),
            new UIPropertyMetadata(null));

        public ReactiveCommand<object> DeleteCommand
        {
            get { return (ReactiveCommand<object>)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
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
