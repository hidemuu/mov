using Mov.Core.Models.ValueObjects.Foods;

namespace Mov.Core.Models.Entities.Foods.Factories
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
