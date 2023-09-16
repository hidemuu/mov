namespace Mov.Core.Stores
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
