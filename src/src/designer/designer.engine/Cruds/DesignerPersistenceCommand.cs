using Mov.Repositories.Services.Cruds;
using Mov.Utilities.Templates.Crud;

namespace Mov.Designer.Engine.Entities
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