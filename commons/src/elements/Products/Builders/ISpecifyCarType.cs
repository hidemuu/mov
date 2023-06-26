using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Elements.Products.Builders
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
