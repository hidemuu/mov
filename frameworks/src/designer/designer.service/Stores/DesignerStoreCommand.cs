using Mov.Core.Stores;

namespace Mov.Designer.Engine.Cruds
{
    public class DesignerStoreCommand<TEntity> : IStoreCommand<TEntity>
    {
        public ISave<TEntity> Saver { get; }

        public IDelete<TEntity> Deleter { get; }

        public DesignerStoreCommand()
        {
        }

        public void Dispose()
        {
        }
    }
}