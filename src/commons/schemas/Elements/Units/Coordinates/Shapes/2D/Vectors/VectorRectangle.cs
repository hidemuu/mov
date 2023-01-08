using Mov.Schemas.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Mov.Schemas.Elements.Units.Coordinates.Shapes._2D.Vectors
{
    internal class VectorRectangle : Vector2D
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x, y), Point2D.Factory.NewCartesianPoint(x + width, y)));
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x + width, y), Point2D.Factory.NewCartesianPoint(x + width, y + height)));
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x, y), Point2D.Factory.NewCartesianPoint(x, y + height)));
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x, y + height), Point2D.Factory.NewCartesianPoint(x + width, y + height)));
        }
    }
}
