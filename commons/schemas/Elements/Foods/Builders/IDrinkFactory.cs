using Mov.Schemas.Elements.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Elements.Foods.Builders
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
