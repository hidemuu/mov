using Mov.Schemas.Layouts.Styles;
using Mov.Schemas.Units.Coordinates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
