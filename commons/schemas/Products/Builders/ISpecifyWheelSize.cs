using Mov.Utilities.Models.ValueObjects.Units;
using Mov.Utilities.Templates.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Elements.Products.Builders
{
    public interface ISpecifyWheelSize
    {
        IBuilder<Car> WithWheels(LengthUnit size);
    }
}
