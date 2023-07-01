using System;
using System.Collections.Generic;

namespace Mov.Core.Graphicers.Shapes.Policies
{
    public abstract class ShapeDecoratorCyclePolicy
    {
        public abstract bool TypeAdditionAllowed(Type type, IList<Type> allTypes);
        public abstract bool ApplicationAllowed(Type type, IList<Type> allTypes);
    }
}
