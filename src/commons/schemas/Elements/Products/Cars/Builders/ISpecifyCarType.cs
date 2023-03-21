using Mov.Schemas.Elements.Products.Cars;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Products.Cars.Builders
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
