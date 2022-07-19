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
    /// GridListColumnControl.xaml の相互作用ロジック
    /// </summary>
    public partial class GridListColumnControl : UserControl
    {

        #region プロパティ

        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register(nameof(Item), typeof(ColumnItem),
            typeof(GridListColumnControl),
            new UIPropertyMetadata(null));

        public ColumnItem Item
        {
            get { return (ColumnItem)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public static readonly DependencyProperty AttributeProperty =
            DependencyProperty.Register(nameof(Attribute), typeof(ColumnAttribute),
            typeof(GridListColumnControl),
            new UIPropertyMetadata(null));

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
        public GridListColumnControl()
        {
            InitializeComponent();
        }

        #endregion コンストラクター
    }
}
