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
    }
}
