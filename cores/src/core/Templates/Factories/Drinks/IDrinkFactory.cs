using Mov.Core.Models.Entities.Foods;

namespace Mov.Core.Templates.Factories.Drinks
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
