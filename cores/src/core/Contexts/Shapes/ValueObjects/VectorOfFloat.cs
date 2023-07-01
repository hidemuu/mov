namespace Mov.Core.Contexts.Shapes.ValueObjects
{
    public class VectorOfFloat<TSelf, D>
    : Vector<TSelf, float, D>
    where D : IDimension, new()
    where TSelf : Vector<TSelf, float, D>, new()
    {
    }
}
