using Mov.Core.Stores;
using Mov.Designer.Models;
using Mov.Designer.Models.Entities;
using System;

namespace Mov.Designer.Engine.Cruds
{
    public class DesignerStoreQuery : IDesignerStoreQuery
    {
        private readonly IDesignerRepository _repository;

        public IStoreQuery<DesignerContent, Guid> Contents { get; }

        public IStoreQuery<DesignerNode, Guid> Nodes { get; }

        public IStoreQuery<DesignerShell, Guid> Shells { get; }

        public IStoreQuery<DesignerTheme, Guid> Themes { get; }

        public DesignerStoreQuery(IDesignerRepository repository)
        {
            _repository = repository;
        }

    }
}