using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Services.Shapes.Policies
{
    public abstract class ShapeDecoratorCyclePolicy
    {
        public abstract bool TypeAdditionAllowed(Type type, IList<Type> allTypes);
        public abstract bool ApplicationAllowed(Type type, IList<Type> allTypes);
    }
}
