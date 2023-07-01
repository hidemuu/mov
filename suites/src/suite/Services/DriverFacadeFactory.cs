using Mov.Driver.Models;
using Mov.Suite.Driver.Engine;

namespace Mov.Suite.Services
{
    public static class DriverFacadeFactory
    {
        public static IDriverFacade Create(IDriverRepository repository)
        {
            if (repository == null) return new EmptyDriverFacade();
            return new DriverFacade(repository);
        }
    }
}