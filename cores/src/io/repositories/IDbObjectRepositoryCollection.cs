using System.Collections.Generic;

namespace Mov.Core.Repositories
{
    public interface IDbObjectRepositoryCollection<TRepository, TEntity, TKey>
        where TRepository : IDbObjectRepository<TEntity, TKey>
        where TEntity : IDbObject<TKey>
    {
        #region method

        IEnumerable<string> GetKeys();

        /// <summary>
        /// 指定のリポジトリを取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TRepository GetRepository(string key);

        #endregion method
    }
}