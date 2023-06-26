using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Graphicers.Services.Shapes.Policies
{
    public class ThrowOnCyclePolicy : ShapeDecoratorCyclePolicy
    {
        private bool handler(Type type, IList<Type> allTypes)
        {
            if (allTypes.Contains(type))
                throw new InvalidOperationException(
                  $"Cycle detected! Type is already a {type.FullName}!");
            return true;
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }

        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return handler(type, allTypes);
        }
    }
}
