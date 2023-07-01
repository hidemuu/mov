using Mov.Core.Models;

namespace Mov.Core.Graphicers.Models.Shapes
{
    public class VectorOfFloat<TSelf, D>
    : Vector<TSelf, float, D>
    where D : IDimension, new()
    where TSelf : Vector<TSelf, float, D>, new()
    {
    }
}
