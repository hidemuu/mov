using Mov.Core.Stores;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;

namespace Mov.Designer.Service.Stores
{
    public class DesignerStoreCommand : IDesignerStoreCommand
    {
        private readonly IDesignerRepository _repository;

        public IStoreCommand<DesignerContent> Contents { get; }

        public IStoreCommand<DesignerNode> Nodes { get; }

        public IStoreCommand<DesignerShell> Shells { get; }

        public IStoreCommand<DesignerTheme> Themes { get; }

        public DesignerStoreCommand(IDesignerRepository repository)
        {
            _repository = repository;
        }

    }
}