﻿using Mov.Designer.Models;
using Mov.Designer.Models.Schemas;
using Mov.Repositories.Services.Cruds;

namespace Mov.Designer.Engine.Persistences
{
    public class RepositoryDesignerCommand : IDesignerCommand
    {
        public IPersistenceCommand<ContentSchema> Contents { get; }

        public IPersistenceCommand<NodeSchema> Nodes { get; }

        public IPersistenceCommand<ShellSchema> Shells { get; }

        public IPersistenceCommand<ThemeSchema> Themes { get; }

        public RepositoryDesignerCommand(IDesignerRepository repository)
        {
            Nodes = new DbObjectRepositoryCommand<NodeSchema, NodeCollection>(repository.Nodes);
            Contents = new DbObjectRepositoryCommand<ContentSchema, ContentCollection>(repository.Contents);
            Shells = new DbObjectRepositoryCommand<ShellSchema, ShellCollection>(repository.Shells);
            Themes = new DbObjectRepositoryCommand<ThemeSchema, ThemeCollection>(repository.Themes);
        }
    }
}