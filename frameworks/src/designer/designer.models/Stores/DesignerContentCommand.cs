using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Stores
{
    public class DesignerContentCommand : IStoreCommand<DesignerContent, Guid>
    {
        public ISave<DesignerContent> Saver => throw new NotImplementedException();

        public IDelete<DesignerContent, Guid> Deleter => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
