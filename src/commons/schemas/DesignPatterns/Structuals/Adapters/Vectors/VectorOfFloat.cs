using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Adapters.Vectors
{
    public class VectorOfFloat<TSelf, D>
    : Vector<TSelf, float, D>
    where D : IInteger, new()
    where TSelf : Vector<TSelf, float, D>, new()
    {
    }
}
