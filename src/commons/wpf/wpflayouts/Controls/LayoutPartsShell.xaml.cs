using Mov.Layouts;
using Mov.Layouts.Contexts;
using Mov.Schemas.Styles;
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

namespace Mov.WpfLayouts.Controls
{
    /// <summary>
    /// LayoutPartsShell.xaml の相互作用ロジック
    /// </summary>
    public partial class LayoutPartsShell : UserControl
    {
        
        #region プロパティ

        #region センター

        public static readonly DependencyProperty ModelsProperty =
            DependencyProperty.Register(nameof(Models), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNode>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNode> Models
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(ModelsProperty); }
            set { SetValue(ModelsProperty, value); }
        }

        public static readonly DependencyProperty ModelBackgroundProperty =
            DependencyProperty.Register(nameof(ModelBackground), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush ModelBackground
        {
            get { return (Brush)GetValue(ModelBackgroundProperty); }
            set { SetValue(ModelBackgroundProperty, value); }
        }

        public static readonly DependencyProperty ModelBorderBrushProperty =
            DependencyProperty.Register(nameof(ModelBorderBrush), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush ModelBorderBrush
        {
            get { return (Brush)GetValue(ModelBorderBrushProperty); }
            set { SetValue(ModelBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty ModelBorderThicknessProperty =
            DependencyProperty.Register(nameof(ModelBorderThickness), typeof(Thickness),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new Thickness{ Top =1, Bottom = 1, Left = 1, Right = 1 }));

        public Thickness ModelBorderThickness
        {
            get { return (Thickness)GetValue(ModelBorderThicknessProperty); }
            set { SetValue(ModelBorderThicknessProperty, value); }
        }

        #endregion センター

        #region トップ

        public static readonly DependencyProperty TopModelsProperty =
            DependencyProperty.Register(nameof(TopModels), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNode>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNode> TopModels
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(TopModelsProperty); }
            set { SetValue(TopModelsProperty, value); }
        }

        public static readonly DependencyProperty TopHeightProperty =
            DependencyProperty.Register(nameof(TopHeight), typeof(double),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(50.0));

        public double TopHeight
        {
            get { return (double)GetValue(TopHeightProperty); }
            set { SetValue(TopHeightProperty, value); }
        }

        public static readonly DependencyProperty TopBackgroundProperty =
            DependencyProperty.Register(nameof(TopBackground), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush TopBackground
        {
            get { return (Brush)GetValue(TopBackgroundProperty); }
            set { SetValue(TopBackgroundProperty, value); }
        }

        public static readonly DependencyProperty TopBorderBrushProperty =
            DependencyProperty.Register(nameof(TopBorderBrush), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush TopBorderBrush
        {
            get { return (Brush)GetValue(TopBorderBrushProperty); }
            set { SetValue(TopBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty TopBorderThicknessProperty =
            DependencyProperty.Register(nameof(TopBorderThickness), typeof(Thickness),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new Thickness { Top = 1, Bottom = 1, Left = 1, Right = 1 }));

        public Thickness TopBorderThickness
        {
            get { return (Thickness)GetValue(TopBorderThicknessProperty); }
            set { SetValue(TopBorderThicknessProperty, value); }
        }

        #endregion トップ

        #region ボトム

        public static readonly DependencyProperty BottomModelsProperty =
            DependencyProperty.Register(nameof(BottomModels), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNode>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNode> BottomModels
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(BottomModelsProperty); }
            set { SetValue(BottomModelsProperty, value); }
        }

        public static readonly DependencyProperty BottomHeightProperty =
            DependencyProperty.Register(nameof(BottomHeight), typeof(double),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(50.0));

        public double BottomHeight
        {
            get { return (double)GetValue(BottomHeightProperty); }
            set { SetValue(BottomHeightProperty, value); }
        }

        public static readonly DependencyProperty BottomBackgroundProperty =
            DependencyProperty.Register(nameof(BottomBackground), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush BottomBackground
        {
            get { return (Brush)GetValue(BottomBackgroundProperty); }
            set { SetValue(BottomBackgroundProperty, value); }
        }

        public static readonly DependencyProperty BottomBorderBrushProperty =
            DependencyProperty.Register(nameof(BottomBorderBrush), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush BottomBorderBrush
        {
            get { return (Brush)GetValue(BottomBorderBrushProperty); }
            set { SetValue(BottomBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty BottomBorderThicknessProperty =
            DependencyProperty.Register(nameof(BottomBorderThickness), typeof(Thickness),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new Thickness { Top = 1, Bottom = 1, Left = 1, Right = 1 }));

        public Thickness BottomBorderThickness
        {
            get { return (Thickness)GetValue(BottomBorderThicknessProperty); }
            set { SetValue(BottomBorderThicknessProperty, value); }
        }

        #endregion ボトム

        #region レフト

        public static readonly DependencyProperty LeftModelsProperty =
            DependencyProperty.Register(nameof(LeftModels), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNode>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNode> LeftModels
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(LeftModelsProperty); }
            set { SetValue(LeftModelsProperty, value); }
        }

        public static readonly DependencyProperty LeftWidthProperty =
            DependencyProperty.Register(nameof(LeftWidth), typeof(double),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(100.0));

        public double LeftWidth
        {
            get { return (double)GetValue(LeftWidthProperty); }
            set { SetValue(LeftWidthProperty, value); }
        }

        public static readonly DependencyProperty LeftBackgroundProperty =
            DependencyProperty.Register(nameof(LeftBackground), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush LeftBackground
        {
            get { return (Brush)GetValue(LeftBackgroundProperty); }
            set { SetValue(LeftBackgroundProperty, value); }
        }

        public static readonly DependencyProperty LeftBorderBrushProperty =
            DependencyProperty.Register(nameof(LeftBorderBrush), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush LeftBorderBrush
        {
            get { return (Brush)GetValue(LeftBorderBrushProperty); }
            set { SetValue(LeftBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty LeftBorderThicknessProperty =
            DependencyProperty.Register(nameof(LeftBorderThickness), typeof(Thickness),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new Thickness { Top = 1, Bottom = 1, Left = 1, Right = 1 }));

        public Thickness LeftBorderThickness
        {
            get { return (Thickness)GetValue(LeftBorderThicknessProperty); }
            set { SetValue(LeftBorderThicknessProperty, value); }
        }

        #endregion レフト

        #region ライト

        public static readonly DependencyProperty RightModelsProperty =
            DependencyProperty.Register(nameof(RightModels), typeof(ReactiveCollection<LayoutNode>),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new ReactiveCollection<LayoutNode>(), new PropertyChangedCallback(OnModelsChanged)));

        public ReactiveCollection<LayoutNode> RightModels
        {
            get { return (ReactiveCollection<LayoutNode>)GetValue(RightModelsProperty); }
            set { SetValue(RightModelsProperty, value); }
        }

        public static readonly DependencyProperty RightWidthProperty =
            DependencyProperty.Register(nameof(RightWidth), typeof(double),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(100.0));

        public double RightWidth
        {
            get { return (double)GetValue(RightWidthProperty); }
            set { SetValue(RightWidthProperty, value); }
        }

        public static readonly DependencyProperty RightBackgroundProperty =
            DependencyProperty.Register(nameof(RightBackground), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush RightBackground
        {
            get { return (Brush)GetValue(RightBackgroundProperty); }
            set { SetValue(RightBackgroundProperty, value); }
        }

        public static readonly DependencyProperty RightBorderBrushProperty =
            DependencyProperty.Register(nameof(RightBorderBrush), typeof(Brush),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(Brushes.Transparent));

        public Brush RightBorderBrush
        {
            get { return (Brush)GetValue(RightBorderBrushProperty); }
            set { SetValue(RightBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty RightBorderThicknessProperty =
            DependencyProperty.Register(nameof(RightBorderThickness), typeof(Thickness),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(new Thickness { Top = 1, Bottom = 1, Left = 1, Right = 1 }));

        public Thickness RightBorderThickness
        {
            get { return (Thickness)GetValue(RightBorderThicknessProperty); }
            set { SetValue(RightBorderThicknessProperty, value); }
        }

        #endregion ライト

        #region サービス

        public static readonly DependencyProperty ServiceProperty =
            DependencyProperty.Register(nameof(Service), typeof(ILayoutService),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(null, new PropertyChangedCallback(OnRepositoryChanged)));


        public ILayoutService Service
        {
            get { return (ILayoutService)GetValue(ServiceProperty); }
            set { SetValue(ServiceProperty, value); }
        }

        public static readonly DependencyProperty RepositoryNameProperty =
            DependencyProperty.Register(nameof(RepositoryName), typeof(string),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(string.Empty, new PropertyChangedCallback(OnRepositoryChanged)));

        public string RepositoryName
        {
            get { return (string)GetValue(RepositoryNameProperty); }
            set { SetValue(RepositoryNameProperty, value); }
        }

        public static readonly DependencyProperty IsUpdateProperty =
            DependencyProperty.Register(nameof(IsUpdate), typeof(bool),
            typeof(LayoutPartsShell),
            new UIPropertyMetadata(true, new PropertyChangedCallback(OnUpdateChanged)));

        public bool IsUpdate
        {
            get { return (bool)GetValue(IsUpdateProperty); }
            set { SetValue(IsUpdateProperty, value); }
        }

        #endregion サービス

        #endregion プロパティ

        #region コンストラクター

        public LayoutPartsShell()
        {
            InitializeComponent();
        }

        #endregion コンストラクター

        #region イベント

        private static void OnModelsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as LayoutPartsShell;
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
            var control = obj as LayoutPartsShell;
            if (control != null)
            {
                if (control.Service != null)
                {
                    if (control.IsUpdate)
                    {
                        control.Models.Clear();
                        control.TopModels.Clear();
                        control.BottomModels.Clear();
                        control.LeftModels.Clear();
                        control.RightModels.Clear();
                        var service = control.Service;

                        control.Models.AddRange(service.GetRegionNode(RegionStyle.Center).Children);
                        control.TopModels.AddRange(service.GetRegionNode(RegionStyle.Top).Children);
                        control.BottomModels.AddRange(service.GetRegionNode(RegionStyle.Bottom).Children);
                        control.LeftModels.AddRange(service.GetRegionNode(RegionStyle.Left).Children);
                        control.RightModels.AddRange(service.GetRegionNode(RegionStyle.Right).Children);

                        var topShell = service.GetRegionShell(RegionStyle.Top);
                        var bottomShell = service.GetRegionShell(RegionStyle.Bottom);
                        var leftShell = service.GetRegionShell(RegionStyle.Left);
                        var rightShell = service.GetRegionShell(RegionStyle.Right);
                        var centerShell = service.GetRegionShell(RegionStyle.Center);

                        if (topShell != null)
                        {
                            control.TopHeight = topShell.Size.Height.Value;
                            control.TopBackground = (SolidColorBrush)new BrushConverter().ConvertFromString(topShell.BackgroundColor.Value);
                            control.TopBorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(topShell.BorderColor.Value);
                            control.TopBorderThickness = new Thickness(topShell.BorderThickness.Value);
                        }
                        if (bottomShell != null)
                        {
                            control.BottomHeight = bottomShell.Size.Height.Value;
                            control.BottomBackground = (SolidColorBrush)new BrushConverter().ConvertFromString(bottomShell.BackgroundColor.Value);
                            control.BottomBorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(bottomShell.BorderColor.Value);
                            control.BottomBorderThickness = new Thickness(bottomShell.BorderThickness.Value);
                        }
                        if (leftShell != null)
                        {
                            control.LeftWidth = leftShell.Size.Width.Value;
                            control.LeftBackground = (SolidColorBrush)new BrushConverter().ConvertFromString(leftShell.BackgroundColor.Value);
                            control.LeftBorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(leftShell.BorderColor.Value);
                            control.LeftBorderThickness = new Thickness(leftShell.BorderThickness.Value);
                        }
                        if (rightShell != null)
                        {
                            control.RightWidth = rightShell.Size.Width.Value;
                            control.RightBackground = (SolidColorBrush)new BrushConverter().ConvertFromString(rightShell.BackgroundColor.Value);
                            control.RightBorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(rightShell.BorderColor.Value);
                            control.RightBorderThickness = new Thickness(rightShell.BorderThickness.Value);
                        }
                        if (centerShell != null)
                        {
                            control.ModelBackground = (SolidColorBrush)new BrushConverter().ConvertFromString(centerShell.BackgroundColor.Value);
                            control.ModelBorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(centerShell.BorderColor.Value);
                            control.ModelBorderThickness = new Thickness(centerShell.BorderThickness.Value);
                        }
                    }
                }
            }
        }

        #endregion 内部メソッド
    }
}
