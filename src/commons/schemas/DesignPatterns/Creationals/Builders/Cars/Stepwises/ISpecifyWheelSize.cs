using Mov.Schemas.Elements.Products;
using Mov.Schemas.Units;
using Mov.Shemas.DesignPatterns.Creationals.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Builders.Cars.Stepwises
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
