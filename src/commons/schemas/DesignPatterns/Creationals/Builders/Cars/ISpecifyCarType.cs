using Mov.Schemas.Elements.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shemas.DesignPatterns.Creationals.Builders.Cars
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
