namespace Mov.Core.Models.Entities.Shapes
{
    public interface IShape
    {
        void Draw();

        void Resize(float factor);
    }
}
