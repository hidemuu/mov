using Mov.Core.Models.Dimensions.Coordinates.TwoDimensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Mov.Core.Models.Dimensions.Coordinates
{
    public class LineToPoint2DAdapter : IEnumerable<Point2D>
    {
        private static int count = 0;
        private static Dictionary<int, List<Point2D>> cache = new Dictionary<int, List<Point2D>>();
        private int hash;

        public LineToPoint2DAdapter(Line2D line)
        {
            hash = line.GetHashCode();
            if (cache.ContainsKey(hash)) return; // we already have it

            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X.Value},{line.Start.Y.Value}]-[{line.End.X.Value},{line.End.Y}] (no caching)");

            var left = Math.Min(line.Start.X.Value, line.End.X.Value);
            var right = Math.Max(line.Start.X.Value, line.End.X.Value);
            var top = Math.Min(line.Start.Y.Value, line.End.Y.Value);
            var bottom = Math.Max(line.Start.Y.Value, line.End.Y.Value);
            var dx = right - left;
            var dy = line.End.Y.Value - line.Start.Y.Value;

            List<Point2D> points = new List<Point2D>();

            if (dx == 0)
            {
                for (var y = top; y <= bottom; ++y)
                {
                    points.Add(Point2D.Factory.NewCartesianPoint(left, y));
                }
            }
            else if (dy == 0)
            {
                for (var x = left; x <= right; ++x)
                {
                    points.Add(Point2D.Factory.NewCartesianPoint(x, top));
                }
            }

            cache.Add(hash, points);
        }

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
