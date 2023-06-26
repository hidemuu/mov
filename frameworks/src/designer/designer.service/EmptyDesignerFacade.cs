using Mov.Designer.Models;
using Mov.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Service
{
    public class EmptyDesignerFacade : IDesignerFacade
    {
        public IDesignerCommand Command => throw new NotImplementedException();

        public IDesignerQuery Query => throw new NotImplementedException();

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
