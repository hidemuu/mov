using Mov.Schemas.Elements.Products;
using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Creators.Builders.Cars.Stepwises
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
