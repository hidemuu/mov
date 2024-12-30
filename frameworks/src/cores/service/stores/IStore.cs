namespace Mov.Core.Stores
{
    public interface IStore<TEntity, TIdentifier>
    {
        IStoreQuery<TEntity, TIdentifier> Query { get; }
        IStoreCommand<TEntity> Command { get; }

    }
}
