using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovCartesianChart : CartesianChart
    {
        static MovCartesianChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovCartesianChart), new FrameworkPropertyMetadata(typeof(MovCartesianChart)));
        }

        #region プロパティ

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
