using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Products.Cars.Builders
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
