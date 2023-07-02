using Mov.Core.Models.Units.Coordinates;
using System.Collections;
using System.Collections.Generic;

namespace Mov.Analizer.Models.Entities.Charts
{
    public class CartesianChartSeries : IEnumerable<Point2D>
    {
        private static int count = 0;
        private static Dictionary<int, List<Point2D>> cache = new Dictionary<int, List<Point2D>>();
        private int hash;

        public IEnumerator<Point2D> GetEnumerator()
        {
            return cache[hash].GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}