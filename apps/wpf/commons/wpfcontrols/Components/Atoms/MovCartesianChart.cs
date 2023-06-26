using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Mov.Schemas.Units.Coordinates;
using Mov.WpfControls.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovCartesianChart : CartesianChart
    {
        static MovCartesianChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovCartesianChart), new FrameworkPropertyMetadata(typeof(MovCartesianChart)));
        }

        #region プロパティ

        public IEnumerable<Point2D> Points
        {
            get 
            {
                var value = (ChartValues<ObservablePoint>)GetValue(PointsProperty);
                return value.GetPoint2Ds(); 
            }
            set { SetValue(PointsProperty, value.GetChartValues()); }
        }

        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register(nameof(Points), typeof(ChartValues<ObservablePoint>), typeof(MovCartesianChart), new PropertyMetadata(default));

        public string BackgroundColor
        {
            get 
            {
                var value = (Brush)GetValue(BackgroundColorProperty);
                return value.ToString();
            }
            set { SetValue(BackgroundColorProperty, value.GetBrush()); }
        }

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register(nameof(BackgroundColor), typeof(Brush), typeof(MovCartesianChart), new PropertyMetadata(default));

        public string ForegroundColor
        {
            get { return (string)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register(nameof(ForegroundColor), typeof(Brush), typeof(MovCartesianChart), new PropertyMetadata(default));


        public IEnumerable<string> LabelsX
        {
            get { return (IEnumerable<string>)GetValue(LabelsXProperty); }
            set { SetValue(LabelsXProperty, value); }
        }

        public static readonly DependencyProperty LabelsXProperty =
            DependencyProperty.Register(nameof(LabelsX), typeof(IEnumerable<string>), typeof(MovCartesianChart), new PropertyMetadata(default));

        public double MaxValueY
        {
            get { return (double)GetValue(MaxValueYProperty); }
            set { SetValue(MaxValueYProperty, value); }
        }

        public static readonly DependencyProperty MaxValueYProperty =
            DependencyProperty.Register(nameof(MaxValueY), typeof(double), typeof(MovCartesianChart), new PropertyMetadata(default));

        public double MinValueY
        {
            get { return (double)GetValue(MinValueYProperty); }
            set { SetValue(MinValueYProperty, value); }
        }

        public static readonly DependencyProperty MinValueYProperty =
            DependencyProperty.Register(nameof(MinValueY), typeof(double), typeof(MovCartesianChart), new PropertyMetadata(default));


        #endregion プロパティ

    }
}
