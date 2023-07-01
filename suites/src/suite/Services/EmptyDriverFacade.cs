using Mov.Driver.Models;
using Mov.Suite.Driver.Engine;
using System;

namespace Mov.Suite.Services
{
    internal class EmptyDriverFacade : IDriverFacade
    {
        public IDriverRepository Repository => throw new NotImplementedException();
    }
}