using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Implements.DbObjects
{
    /// <summary>
    /// 任意のエンティティのファイルデータのリポジトリ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TBody"></typeparam>
    public class FileDbObjectRepository<TEntity, TKey> : IDbObjectRepository<TEntity, TKey>
        where TEntity : IDbObject<TKey>
    {
        #region field

        protected readonly ISerializer serializer;

        #endregion field

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDbObjectRepository(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        #endregion constructor

        #region method

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Task.Run(() => this.serializer.Deserialize<TEntity, IEnumerable<TEntity>>(""));
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
            await Task.Run(() => this.serializer.Serialize<TEntity, TEntity>("", item));
        }

        /// <inheritdoc />
        public async Task PostAsync(IEnumerable<TEntity> items)
        {
            await Task.Run(() => this.serializer.Serialize<IEnumerable<TEntity>, IEnumerable<TEntity>>("", items));
        }

        /// <inheritdoc />
        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}