using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Products.Cars.Builders
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
