using LiveCharts;
using LiveCharts.Defaults;
using Mov.Core.Valuables.Dimensions.Coordinates;
using System.Collections.Generic;

namespace Mov.Suite.WpfApp.Shared.Extensions
{
    internal static class Point2DsExtension
    {
        internal static ChartValues<ObservablePoint> GetChartValues(this IEnumerable<Point2D> point2Ds)
        {
            var chartValues = new ChartValues<ObservablePoint>();
            foreach (Point2D point in point2Ds)
            {
                chartValues.Add(new ObservablePoint(point.X.Value, point.Y.Value));
            }
            return chartValues;
        }
    }
}
