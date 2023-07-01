namespace Mov.Core.Templates
{
    public interface IDatabase<TEntity, TKey>
    {
        TEntity Get(TKey key);

        void Delete(TKey key);

        void Put(TEntity value);

        void Post(TEntity value);


    }
}
