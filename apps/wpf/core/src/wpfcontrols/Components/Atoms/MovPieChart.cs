using LiveCharts.Wpf;
using System.Windows;

namespace Mov.WpfControls.Components.Atoms
{
    public class MovPieChart : PieChart
    {
        static MovPieChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MovPieChart), new FrameworkPropertyMetadata(typeof(MovPieChart)));
        }

        #region プロパティ



        #endregion プロパティ

    }
}
