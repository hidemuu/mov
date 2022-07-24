using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfControls.Components
{
    /// <summary>
    /// ツリー型のリストビューコントロール
    /// </summary>
    /// <remarks>https://sabeeshwpf.blogspot.com/2012/12/treelistview-in-wpf.html</remarks>
    public class TreeListView : TreeView
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
           DependencyProperty.Register("Columns", typeof(GridViewColumnCollection),
           typeof(TreeListView),
           new UIPropertyMetadata(null));

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
                typeof(TreeListView),
                new UIPropertyMetadata(null));

        #endregion プロパティ

        #region コンストラクター

        static TreeListView()
        {
            //Override the default style and the default control template
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeListView), new FrameworkPropertyMetadata(typeof(TreeListView)));
        }

        /// <summary>
        /// Initialize a new instance of TreeListView.
        /// </summary>
        public TreeListView()
        {
            Columns = new GridViewColumnCollection();
        }

        #endregion コンストラクター

    }
}