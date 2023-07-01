using Mov.Core.Models.Entities.Foods;

namespace Mov.Core.Models.Factories
{
    public interface IDrinkFactory
    {
        Drink Prepare(int amount);
    }
}
