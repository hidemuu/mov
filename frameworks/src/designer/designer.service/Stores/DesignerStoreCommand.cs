using Mov.Core.Stores;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;
using System;

namespace Mov.Designer.Engine.Cruds
{
    public class DesignerStoreCommand : IDesignerStoreCommand
    {
        private readonly IDesignerRepository _repository;

        public IStoreCommand<DesignerContent, Guid> Contents { get; }

        public IStoreCommand<DesignerNode, Guid> Nodes { get; }

        public IStoreCommand<DesignerShell, Guid> Shells { get; }

        public IStoreCommand<DesignerTheme, Guid> Themes { get; }

        public DesignerStoreCommand(IDesignerRepository repository) 
        {
            _repository = repository;
        }

    }
}