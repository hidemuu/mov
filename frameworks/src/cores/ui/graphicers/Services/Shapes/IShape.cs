namespace Mov.Core.Graphicers.Services.Shapes
{
    public interface IShape
    {
        void Draw();

        void Resize(float factor);
    }
}
