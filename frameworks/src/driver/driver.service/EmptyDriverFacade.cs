using Mov.Driver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Service
{
    internal class EmptyDriverFacade : IDriverFacade
    {
        public IDriverRepository Repository => throw new NotImplementedException();
    }
}
