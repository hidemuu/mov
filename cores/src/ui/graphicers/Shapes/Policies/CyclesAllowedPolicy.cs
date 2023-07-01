using System;
using System.Collections.Generic;

namespace Mov.Core.Graphicers.Shapes.Policies
{
    public class CyclesAllowedPolicy : ShapeDecoratorCyclePolicy
    {
        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }
    }
}
