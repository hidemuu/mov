using Mov.Core.Valuables.Dimensions.Coordinates;
using System.Collections;
using System.Collections.Generic;

namespace Mov.Core.Charts.Models.Entities
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
