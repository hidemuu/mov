using LiveCharts.Defaults;
using LiveCharts;
using Mov.Schemas.Units.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.WpfControls.Extensions
{
    internal static class ChartValuesExtensions
    {
        internal static IEnumerable<Point2D> GetPoint2Ds(this ChartValues<ObservablePoint> point2Ds)
        {
            foreach (var point in point2Ds)
            {
                yield return Point2D.Factory.NewCartesianPoint(point.X, point.Y);
            }
        }
    }
}
