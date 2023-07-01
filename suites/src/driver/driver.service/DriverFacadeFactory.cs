using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Service
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
