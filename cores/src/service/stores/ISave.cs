namespace Mov.Core.Stores
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
