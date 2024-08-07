﻿using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Models;
using Mov.Core.Repositories.Schemas.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
    /// <summary>
    /// 任意のエンティティのファイルデータのリポジトリ
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TIdentifier"></typeparam>
    public class FileDbRepository<TEntity, TIdentifier> : IDbRepository<TEntity, TIdentifier, DbRequestSchemaString>
        where TEntity : IDbSchema<TIdentifier>
    {
        #region field

        private readonly IClient _client;

        #endregion field

        #region property

        public string Name { get; }

        public string Endpoint => _client.Endpoint.Value;

        #endregion property

        #region constructor

        /// <summary>
        /// base constructor
        /// </summary>
        private FileDbRepository(IClient client, string name)
        {
            _client = client;
            this.Name = name;
        }

        /// <summary>
        /// factory
        /// </summary>
        public static class Factory
        {
            public static FileDbRepository<TEntity, TIdentifier> Create(IClient client) => new FileDbRepository<TEntity, TIdentifier>(client, string.Empty);

            public static FileDbRepository<TEntity, TIdentifier> Create(string endpoint, FileType fileType, EncodingValue encoding)
            {
                return new FileDbRepository<TEntity, TIdentifier>(new FileClient(new PathValue(endpoint), encoding, AccessType.Create(fileType)), string.Empty);
            }

            public static FileDbRepository<TEntity, TIdentifier> Create(PathValue endpoint, FileType fileType, EncodingValue encoding)
            {
                return new FileDbRepository<TEntity, TIdentifier>(new FileClient(endpoint, encoding, AccessType.Create(fileType)), string.Empty);
            }
        }

        #endregion constructor

        #region method

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetsAsync()
        {
            return await _client.GetsAsync<TEntity>("").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(TIdentifier identifier)
        {
            var items = await GetsAsync().ConfigureAwait(false);
            return items.FirstOrDefault(x => x.Id.Equals(identifier));
        }

		public async Task<TEntity> GetRequestAsync(DbRequestSchemaString request)
		{
			var items = await GetsAsync();
			return items.FirstOrDefault(x => x.Id.Equals(request.Uri));
		}

		/// <inheritdoc />
		public async Task<ResponseStatus> PostsAsync(IEnumerable<TEntity> entities)
		{
			return await _client.PostAsync("", entities);
		}

		/// <inheritdoc />
		public async Task<ResponseStatus> PostAsync(TEntity entity)
        {
            return await _client.PostAsync("", entity);
        }

        public async Task<ResponseStatus> PutAsync(TEntity entity)
        {
            return await _client.PutAsync("", entity);
        }

		public async Task<ResponseStatus> DeletesAsync()
		{
            return await _client.DeletesAsync("");
		}

		/// <inheritdoc />
		public async Task<ResponseStatus> DeleteAsync(TEntity entity)
        {
            return await _client.DeleteAsync("", entity);
        }

		#endregion method
	}
}