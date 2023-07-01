using Mov.Driver.Models;
using Mov.Suite.Driver.Engine;

namespace Mov.Suite.Services
{
    public class DriverFacade : IDriverFacade
    {
        public IDriverRepository Repository { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DriverFacade(IDriverRepository repository)
        {
            Repository = repository;
        }
    }
}