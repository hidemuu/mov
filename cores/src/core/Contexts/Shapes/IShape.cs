namespace Mov.Core.Contexts.Shapes
{
    public interface IShape
    {
        void Draw();

        void Resize(float factor);
    }
}
