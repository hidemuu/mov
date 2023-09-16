using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Stores.Queries
{
    public class DesignerContentReader : IRead<DesignerContent, Guid>
    {
        public DesignerContent Read(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DesignerContent> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
