namespace Mov.Core.Stores
{
    public interface IStoreQuery<TEntity>
    {
        IRead<TEntity> Reader { get; }


    }
}
