using Mov.Core.Stores;
using Mov.Core.Stores.Services.Commands.Savers;
using Mov.Designer.Models.Entities;
using Mov.Designer.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Models.Stores.Commands
{
    public class DesignerContentCommand : IStoreCommand<DesignerContent, Guid>
    {
        public ISave<DesignerContent> Saver { get; }

        public IDelete<DesignerContent, Guid> Deleter { get; }

        public DesignerContentCommand(IDesignerRepository repository)
        {
            Saver = new DesignerContentSaver(repository);
            Deleter= new DesignerContentDeleter(repository);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
