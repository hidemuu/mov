namespace Mov.Core.Stores
{
    public interface IStoreQuery<TEntity, TKey>
    {
        IRead<TEntity, TKey> Reader { get; }


    }
}
