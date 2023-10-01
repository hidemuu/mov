using Mov.Core.Layouts;
using Mov.Designer.Models;
using Mov.Designer.Service;
using System;

namespace Mov.Designer.Controller
{
    public class EmptyDesignerFacade : IDesignerFacade
    {
        public IDesignerStoreCommand Command => throw new NotImplementedException();

        public IDesignerStoreQuery Query => throw new NotImplementedException();

        public ILayoutFacade LayoutFacade => throw new NotImplementedException();

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}