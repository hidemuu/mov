namespace Mov.Core.Graphicers.Models.Shapes
{
    public interface IShape
    {
        void Draw();

        void Resize(float factor);
    }
}
