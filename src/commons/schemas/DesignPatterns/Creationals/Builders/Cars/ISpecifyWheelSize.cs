using Mov.Schemas.Elements.Members;
using Mov.Schemas.Elements.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shemas.DesignPatterns.Creationals.Builders.Cars
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
