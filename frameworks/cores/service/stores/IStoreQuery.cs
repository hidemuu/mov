namespace Mov.Core.Stores
{
    public interface IStoreQuery<TEntity, TIdentifier>
    {
        IRead<TEntity, TIdentifier> Reader { get; }


    }
}
