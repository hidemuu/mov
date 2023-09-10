namespace Mov.Core.Stores.Cruds
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
