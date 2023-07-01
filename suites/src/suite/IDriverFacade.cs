using Mov.Driver.Models;

namespace Mov.Suite.Driver.Engine
{
    public interface IDriverFacade
    {
        IDriverRepository Repository { get; }
    }
}