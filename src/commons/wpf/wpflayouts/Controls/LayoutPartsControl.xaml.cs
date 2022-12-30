using Mov.Layouts;
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

namespace Mov.WpfLayouts.Controls
{
    /// <summary>
    /// DesignerPartsControl.xaml の相互作用ロジック
    /// </summary>
    public partial class LayoutPartsControl : UserControl
    {
        #region プロパティ

        public static readonly DependencyProperty ModelsProperty =
            DependencyProperty.Register(nameof(Models), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsControl),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNode> Models
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(ModelsProperty); }
            set { SetValue(ModelsProperty, value); }
        }

        
        #endregion プロパティ

        #region コンストラクター

        public LayoutPartsControl()
        {
            InitializeComponent();
        }

        #endregion コンストラクター

        #region イベント

        private static void OnModelsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as LayoutPartsControl;
            if (control != null)
            {
                if (control.Models != null || !control.Models.Any())
                {
                    
                }
            }
        }

        #endregion イベント

    }
}
