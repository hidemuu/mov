namespace Mov.Core.Stores
{
    public interface IDelete<TEntity, TKey>
    {
        void Delete(TEntity entity);
    }
}
