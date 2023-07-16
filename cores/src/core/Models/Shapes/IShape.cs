namespace Mov.Core.Models.Shapes
{
    public interface IShape
    {
        void Draw();

        void Resize(float factor);
    }
}
