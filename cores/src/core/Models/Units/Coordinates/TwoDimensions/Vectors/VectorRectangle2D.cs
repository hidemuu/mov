namespace Mov.Core.Models.Units.Coordinates.TwoDimensions.Vectors
{
    internal class VectorRectangle2D : Vector2D
    {
        public VectorRectangle2D(int x, int y, int width, int height)
        {
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x, y), Point2D.Factory.NewCartesianPoint(x + width, y)));
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x + width, y), Point2D.Factory.NewCartesianPoint(x + width, y + height)));
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x, y), Point2D.Factory.NewCartesianPoint(x, y + height)));
            Add(new Line2D(Point2D.Factory.NewCartesianPoint(x, y + height), Point2D.Factory.NewCartesianPoint(x + width, y + height)));
        }
    }
}