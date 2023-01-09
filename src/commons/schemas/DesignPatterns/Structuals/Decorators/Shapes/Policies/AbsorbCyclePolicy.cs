using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Structuals.Decorators.Shapes.Policies
{
    public class AbsorbCyclePolicy : ShapeDecoratorCyclePolicy
    {
        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return !allTypes.Contains(type);
        }
    }
}
