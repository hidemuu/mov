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
        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register(nameof(Columns), typeof(ReactiveCollection<ColumnItem[]>),
            typeof(TreeListView),
            new UIPropertyMetadata(null));

        public ReactiveCollection<ColumnItem[]> Columns
        {
            get { return (ReactiveCollection<ColumnItem[]>)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty SelectedColumnProperty =
            DependencyProperty.Register(nameof(SelectedColumn), typeof(ColumnItem[]),
            typeof(TreeListView),
            new UIPropertyMetadata(null));

        public ColumnItem[] SelectedColumn
        {
            get { return (ColumnItem[])GetValue(SelectedColumnProperty); }
            set { SetValue(SelectedColumnProperty, value); }
        }

        public static readonly DependencyProperty AttributesProperty =
            DependencyProperty.Register(nameof(Attributes), typeof(ReactiveCollection<ColumnAttribute[]>),
            typeof(TreeListView),
            new UIPropertyMetadata(null));

        public ReactiveCollection<ColumnAttribute[]> Attributes
        {
            get { return (ReactiveCollection<ColumnAttribute[]>)GetValue(AttributesProperty); }
            set { SetValue(AttributesProperty, value); }
        }

        public GridListControl()
        {
            InitializeComponent();
        }
    }
}
