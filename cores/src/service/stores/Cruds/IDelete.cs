namespace Mov.Core.Stores.Cruds
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
