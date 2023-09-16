using Mov.Core.Layouts;
using Mov.Designer.Engine;
using Mov.Designer.Models;
using System;

namespace Mov.Designer.Service
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