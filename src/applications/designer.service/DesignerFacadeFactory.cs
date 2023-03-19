using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public static class DesignerFacadeFactory
    {

        public static IDesignerFacade Create(IEnumerable<IDesignerRepository> repositories)
        {
            if (repositories == null) return new EmptyDesignerFacade();
            return new DesignerFacade(repositories);
        }

    }
}
