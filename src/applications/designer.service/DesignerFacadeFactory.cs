using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Service
{
    public static class DesignerFacadeFactory
    {

        public static IDesignerFacade Create(IEnumerable<IDesignerRepository> repositories)
        {
            if (repositories == null) return new EmptyDesignerFacade();
            if (repositories.Count() == 1 && repositories.ToArray()[0] == null) return new EmptyDesignerFacade();
            return new DesignerFacade(repositories);
        }

    }
}
