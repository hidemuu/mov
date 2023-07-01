using LiveCharts;
using LiveCharts.Defaults;
using Mov.Core.Models.ValueObjects.Units.Coordinates;
using System.Collections.Generic;

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