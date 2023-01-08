using Mov.Schemas.Elements.Units.Coordinates;
using Mov.Schemas.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Adapters
{
    public class LineToPointAdapter : Collection<Point2D>
    {
        private static int count = 0;

        public LineToPointAdapter(Line2D line)
        {
            Console.WriteLine($"{++count}: Generating points for line [{line.Start.X.Value},{line.Start.Y.Value}]-[{line.End.X.Value},{line.End.Y}] (no caching)");

            var left = Math.Min(line.Start.X.Value, line.End.X.Value);
            var right = Math.Max(line.Start.X.Value, line.End.X.Value);
            var top = Math.Min(line.Start.Y.Value, line.End.Y.Value);
            var bottom = Math.Max(line.Start.Y.Value, line.End.Y.Value);
            var dx = right - left;
            var dy = line.End.Y.Value - line.Start.Y.Value;

            if (dx == 0)
            {
                for (var y = top; y <= bottom; ++y)
                {
                    Add(Point2D.Factory.NewCartesianPoint(left, y));
                }
            }
            else if (dy == 0)
            {
                for (var x = left; x <= right; ++x)
                {
                    Add(Point2D.Factory.NewCartesianPoint(x, top));
                }
            }
        }
    }
}
