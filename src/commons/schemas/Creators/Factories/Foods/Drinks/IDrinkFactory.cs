using Mov.Schemas.Elements.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Creators.Factories.Foods.Drinks
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
