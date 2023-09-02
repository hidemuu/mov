using Mov.Core.Accessors;
using Mov.Core.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services.DbObjects.Implements
{
    /// <summary>
    /// 任意のエンティティのファイルデータのリポジトリ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class FileDbObjectRepository<TEntity, TKey> : IDbObjectRepository<TEntity, TKey>
        where TEntity : IDbObject<TKey>
    {
        #region field

        private readonly IClient client;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDbObjectRepository(IClient client)
        {
            this.client = client;
        }

        #endregion constructor

        #region method

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await client.GetAsync<TEntity>("");
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(TKey key)
        {
            var items = await GetAsync();
            return items.FirstOrDefault(x => x.Id.Equals(key));
        }

        /// <inheritdoc />
        public async Task PostAsync(TEntity item)
        {
            await client.PostAsync("", item);
        }

        /// <inheritdoc />
        public async Task PostAsync(IEnumerable<TEntity> items)
        {
            await client.PostAsync("", items);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}