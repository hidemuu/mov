using Mov.Core.Models;

namespace Mov.Core.DesignPatterns
{
    public interface IDatabase<TEntity, TIdentifier>
    {
        #region property

        Identifier<int> Id { get; }

        #endregion property

        #region method

        TEntity Get(TIdentifier identifier);

        void Delete(TIdentifier identifier);

        void Put(TEntity value);

        void Post(TEntity value);

        #endregion method

    }
}
