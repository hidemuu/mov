using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Foods.Builders
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
