using Mov.Schemas.Elements.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.DesignPatterns.Creationals.Builders.Cars.Stepwises
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
