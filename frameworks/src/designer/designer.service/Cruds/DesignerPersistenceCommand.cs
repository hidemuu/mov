﻿using Mov.Core.Templates.Crud;

namespace Mov.Designer.Engine.Cruds
{
    public class DesignerPersistenceCommand<TEntity> : IPersistenceCommand<TEntity>
    {
        public ISave<TEntity> Saver { get; }

        public IDelete<TEntity> Deleter { get; }

        public DesignerPersistenceCommand()
        {
        }

        public void Dispose()
        {
        }
    }
}