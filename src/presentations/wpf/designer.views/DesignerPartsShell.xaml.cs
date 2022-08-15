using Mov.Designer.Models;
using Mov.Designer.Service;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Mov.Designer.Views
{
    /// <summary>
    /// DesignerPartsShell.xaml の相互作用ロジック
    /// </summary>
    public partial class DesignerPartsShell : UserControl
    {
        #region フィールド



        #endregion フィールド

        #region プロパティ

        public static readonly DependencyProperty ModelsProperty =
            DependencyProperty.Register(nameof(Models), typeof(ReactiveCollection<LayoutNodeBase>),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNodeBase>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNodeBase> Models
        {
            get { return (ReactiveCollection<LayoutNodeBase>)GetValue(ModelsProperty); }
            set { SetValue(ModelsProperty, value); }
        }

        public static readonly DependencyProperty TopModelsProperty =
            DependencyProperty.Register(nameof(TopModels), typeof(ReactiveCollection<LayoutNodeBase>),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNodeBase>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNodeBase> TopModels
        {
            get { return (ReactiveCollection<LayoutNodeBase>)GetValue(TopModelsProperty); }
            set { SetValue(TopModelsProperty, value); }
        }

        public static readonly DependencyProperty TopHeightProperty =
            DependencyProperty.Register(nameof(TopHeight), typeof(double),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(50.0));

        public double TopHeight
        {
            get { return (double)GetValue(TopHeightProperty); }
            set { SetValue(TopHeightProperty, value); }
        }

        public static readonly DependencyProperty BottomModelsProperty =
            DependencyProperty.Register(nameof(BottomModels), typeof(ReactiveCollection<LayoutNodeBase>),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNodeBase>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNodeBase> BottomModels
        {
            get { return (ReactiveCollection<LayoutNodeBase>)GetValue(BottomModelsProperty); }
            set { SetValue(BottomModelsProperty, value); }
        }

        public static readonly DependencyProperty BottomHeightProperty =
            DependencyProperty.Register(nameof(BottomHeight), typeof(double),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(50.0));

        public double BottomHeight
        {
            get { return (double)GetValue(BottomHeightProperty); }
            set { SetValue(BottomHeightProperty, value); }
        }

        public static readonly DependencyProperty LeftModelsProperty =
            DependencyProperty.Register(nameof(LeftModels), typeof(ReactiveCollection<LayoutNodeBase>),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNodeBase>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNodeBase> LeftModels
        {
            get { return (ReactiveCollection<LayoutNodeBase>)GetValue(LeftModelsProperty); }
            set { SetValue(LeftModelsProperty, value); }
        }

        public static readonly DependencyProperty LeftWidthProperty =
            DependencyProperty.Register(nameof(LeftWidth), typeof(double),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(100.0));

        public double LeftWidth
        {
            get { return (double)GetValue(LeftWidthProperty); }
            set { SetValue(LeftWidthProperty, value); }
        }

        public static readonly DependencyProperty RightModelsProperty =
            DependencyProperty.Register(nameof(RightModels), typeof(ReactiveCollection<LayoutNodeBase>),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNodeBase>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNodeBase> RightModels
        {
            get { return (ReactiveCollection<LayoutNodeBase>)GetValue(RightModelsProperty); }
            set { SetValue(RightModelsProperty, value); }
        }

        public static readonly DependencyProperty RightWidthProperty =
            DependencyProperty.Register(nameof(RightWidth), typeof(double),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(100.0));

        public double RightWidth
        {
            get { return (double)GetValue(RightWidthProperty); }
            set { SetValue(RightWidthProperty, value); }
        }

        public static readonly DependencyProperty RepositoryProperty =
            DependencyProperty.Register(nameof(Repository), typeof(IDesignerRepository),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnRepositoryChanged)));

        public IDesignerRepository Repository
        {
            get { return (IDesignerRepository)GetValue(RepositoryProperty); }
            set { SetValue(RepositoryProperty, value); }
        }

        public static readonly DependencyProperty IsUpdateProperty =
            DependencyProperty.Register(nameof(IsUpdate), typeof(bool),
            typeof(DesignerPartsShell),
            new UIPropertyMetadata(true, new PropertyChangedCallback(OnUpdateChanged)));

        public bool IsUpdate
        {
            get { return (bool)GetValue(IsUpdateProperty); }
            set { SetValue(IsUpdateProperty, value); }
        }

        #endregion プロパティ

        #region コンストラクター

        public DesignerPartsShell()
        {
            InitializeComponent();
        }

        #endregion コンストラクター

        #region イベント

        private static void OnModelsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as DesignerPartsShell;
            if (control != null)
            {
                if (control.Models != null || !control.Models.Any())
                {

                }
            }
        }

        private static void OnRepositoryChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Update(obj);
        }

        private static void OnUpdateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is bool flg)
            {
                if(flg) Update(obj);
            }
        }

        #endregion イベント

        #region 内部メソッド

        private static void Update(DependencyObject obj)
        {
            var control = obj as DesignerPartsShell;
            if (control != null)
            {
                if (control.Repository != null)
                {
                    if (control.IsUpdate)
                    {
                        var builder = new LayoutBuilder(control.Repository);
                        control.Models.Clear();
                        control.TopModels.Clear();
                        control.BottomModels.Clear();
                        control.LeftModels.Clear();
                        control.RightModels.Clear();
                        var build = builder.Build();
                        if(build.CenterNode == null)
                        {
                            control.Models.AddRange(build.Nodes);
                        }
                        else
                        {
                            control.Models.AddRange(build.CenterNode.Children);
                        }
                        control.TopModels.AddRange(build.TopNode.Children);
                        control.BottomModels.AddRange(build.BottomNode.Children);
                        control.LeftModels.AddRange(build.LeftNode.Children);
                        control.RightModels.AddRange(build.RightNode.Children);

                        var topShell = control.Repository?.Shells?.Get("Top");
                        var bottomShell = control.Repository?.Shells?.Get("Bottom");
                        var leftShell = control.Repository?.Shells?.Get("Left");
                        var rightShell = control.Repository?.Shells?.Get("Right");
                        var centerShell = control.Repository?.Shells?.Get("Center");

                        if(topShell != null)
                        {
                            control.TopHeight = topShell.Height;
                        }
                        if (bottomShell != null)
                        {
                            control.BottomHeight = bottomShell.Height;
                        }
                        if (leftShell != null)
                        {
                            control.LeftWidth = leftShell.Width;
                        }
                        if (rightShell != null)
                        {
                            control.RightWidth = rightShell.Width;
                        }
                        if (centerShell != null)
                        {
                            
                        }
                    }
                }
            }
        }

        #endregion 内部メソッド
    }
}
