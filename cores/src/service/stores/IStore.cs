namespace Mov.Core.Stores
{
    public interface IStore<TEntity, TKey>
    {
        IStoreQuery<TEntity, TKey> Query { get; }
        IStoreCommand<TEntity> Command { get; }

    }
}
