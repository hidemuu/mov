using Mov.Core.Models.Keys;

namespace Mov.Core.Templates
{
    public interface IDatabase<TEntity, TKey>
    {
        #region property

        IdentifierIndex Id { get; }

        #endregion property

        #region method

        TEntity Get(TKey key);

        void Delete(TKey key);

        void Put(TEntity value);

        void Post(TEntity value);

        #endregion method

    }
}
