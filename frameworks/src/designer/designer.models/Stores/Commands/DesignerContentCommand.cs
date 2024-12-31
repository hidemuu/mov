using Mov.Core.Stores;
using Mov.Designer.Models.Entities;
using System;

namespace Mov.Designer.Models.Stores.Commands
{
    public class DesignerContentCommand : IStoreCommand<DesignerContent>
    {
        public ISave<DesignerContent> Saver { get; }

        public IDelete<DesignerContent> Deleter { get; }

        public DesignerContentCommand(IDesignerRepository repository)
        {
            Saver = new DesignerContentSaver(repository);
            Deleter = new DesignerContentDeleter(repository);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
