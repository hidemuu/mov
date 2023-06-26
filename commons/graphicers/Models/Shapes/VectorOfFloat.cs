using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Models.Shapes
{
    public class VectorOfFloat<TSelf, D>
    : Vector<TSelf, float, D>
    where D : IDimension, new()
    where TSelf : Vector<TSelf, float, D>, new()
    {
    }
}
