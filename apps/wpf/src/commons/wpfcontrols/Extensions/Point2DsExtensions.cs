using LiveCharts;
using LiveCharts.Defaults;
using Mov.Schemas.Units.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfControls.Extensions
{
    internal static class Point2DsExtensions
    {
        internal static ChartValues<ObservablePoint> GetChartValues(this IEnumerable<Point2D> point2Ds)
        {
            var chartValues = new ChartValues<ObservablePoint>();
            foreach(Point2D point in point2Ds)
            {
                chartValues.Add(new ObservablePoint(point.X.Value, point.Y.Value));
            }
            return chartValues;
        }
    }
}
