using Mov.Layouts.Models.Entities;
using Reactive.Bindings;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Mov.WpfLayouts.Controls
{
    /// <summary>
    /// DesignerPartsControl.xaml の相互作用ロジック
    /// </summary>
    public partial class LayoutPartsControl : UserControl
    {
        #region プロパティ

        public static readonly DependencyProperty NodesProperty =
            DependencyProperty.Register(nameof(Nodes), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsControl),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnNodesChanged)));

        public ReactiveCollection<LayoutNode> Nodes
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(NodesProperty); }
            set { SetValue(NodesProperty, value); }
        }

        #endregion プロパティ

        #region コンストラクター

        public LayoutPartsControl()
        {
            InitializeComponent();
        }

        #endregion コンストラクター

        #region イベント

        private static void OnNodesChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as LayoutPartsControl;
            if (control != null)
            {
                if (control.Nodes != null || !control.Nodes.Any())
                {
                }
            }
        }

        #endregion イベント
    }
}