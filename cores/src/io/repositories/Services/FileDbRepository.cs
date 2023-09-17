using CsvHelper;
using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
    /// <summary>
    /// 任意のエンティティのファイルデータのリポジトリ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class FileDbRepository<TEntity, TKey> : IDbRepository<TEntity, TKey>
        where TEntity : IDbSchema<TKey>
    {
        #region field

        private readonly IClient _client;

        #endregion field

        #region property

        public string Endpoint => _client.Endpoint.Value;

        #endregion property

        #region constructor

        /// <summary>
        /// base constructor
        /// </summary>
        private FileDbRepository(IClient client)
        {
            _client = client;
        }

        /// <summary>
        /// factory
        /// </summary>
        public static class Factory
        {
            public static FileDbRepository<TEntity, TKey> Create(IClient client) => new FileDbRepository<TEntity, TKey>(client);

            public static FileDbRepository<TEntity, TKey> Create(string endpoint, FileType fileType, EncodingValue encoding)
            {
                return new FileDbRepository<TEntity, TKey>(new FileClient(new PathValue(endpoint), encoding, AccessType.Create(fileType)));
            }

            public static FileDbRepository<TEntity, TKey> Create(PathValue endpoint, FileType fileType, EncodingValue encoding)
            {
                return new FileDbRepository<TEntity, TKey>(new FileClient(endpoint, encoding, AccessType.Create(fileType)));
            }
        }

        #endregion constructor

        #region method

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _client.GetAsync<TEntity>("");
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
            await _client.PostAsync("", item);
        }

        /// <inheritdoc />
        public async Task PostAsync(IEnumerable<TEntity> items)
        {
            await _client.PostAsync("", items);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}