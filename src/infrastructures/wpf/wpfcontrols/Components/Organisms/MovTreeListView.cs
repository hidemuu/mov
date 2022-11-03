using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components
{
    /// <summary>
    /// ツリー型のリストビューコントロール
    /// </summary>
    /// <remarks>https://sabeeshwpf.blogspot.com/2012/12/treelistview-in-wpf.html</remarks>
    public class MovTreeListView : TreeView
    {

        #region プロパティ

        /// <summary>
        /// Gets or sets the collection of System.Windows.Controls.GridViewColumn
        /// objects that is defined for this TreeListView.
        /// </summary>
        public GridViewColumnCollection Columns
        {
            get { return (GridViewColumnCollection)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public static readonly DependencyProperty ColumnsProperty =
           DependencyProperty.Register(nameof(Columns), typeof(GridViewColumnCollection),
           typeof(MovTreeListView),
           new UIPropertyMetadata(null));

        public static readonly DependencyProperty BindableSelectedItemProperty =
            DependencyProperty.Register(nameof(BindableSelectedItem),
                typeof(object), typeof(MovTreeListView), new UIPropertyMetadata(null));

        /// <summary>
        /// Bind 可能な SelectedItem を表し、SelectedItem を設定または取得します。
        /// </summary>
        public object BindableSelectedItem
        {
            get { return (object)this.GetValue(BindableSelectedItemProperty); }
            set { this.SetValue(BindableSelectedItemProperty, value); }
        }

        /// <summary>
        /// Gets or sets whether columns in a TreeListView can be
        /// reordered by a drag-and-drop operation. This is a dependency property.
        /// </summary>
        public bool AllowsColumnReorder
        {
            get { return (bool)GetValue(AllowsColumnReorderProperty); }
            set { SetValue(AllowsColumnReorderProperty, value); }
        }

        public static readonly DependencyProperty AllowsColumnReorderProperty =
            DependencyProperty.Register("AllowsColumnReorder", typeof(bool),
                typeof(MovTreeListView),
                new UIPropertyMetadata(null));

        #endregion プロパティ

        #region コンストラクター

        static MovTreeListView()
        {
            //Override the default style and the default control template
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovTreeListView), new FrameworkPropertyMetadata(typeof(MovTreeListView)));
        }

        /// <summary>
        /// Initialize a new instance of TreeListView.
        /// </summary>
        public MovTreeListView()
        {
            Columns = new GridViewColumnCollection();
            this.SelectedItemChanged += this.OnSelectedItemChanged;
        }

        #endregion コンストラクター

        #region イベント

        protected virtual void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.SelectedItem == null)
            {
                return;
            }

            this.SetValue(BindableSelectedItemProperty, this.SelectedItem);
        }

        #endregion イベント

    }
}