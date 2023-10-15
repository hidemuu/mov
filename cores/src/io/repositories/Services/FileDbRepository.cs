using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
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
    public class FileDbRepository<TEntity, TIdentifier> : IDbRepository<TEntity, TIdentifier>
        where TEntity : IDbSchema<TIdentifier>
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
            public static FileDbRepository<TEntity, TIdentifier> Create(IClient client) => new FileDbRepository<TEntity, TIdentifier>(client);

            public static FileDbRepository<TEntity, TIdentifier> Create(string endpoint, FileType fileType, EncodingValue encoding)
            {
                return new FileDbRepository<TEntity, TIdentifier>(new FileClient(new PathValue(endpoint), encoding, AccessType.Create(fileType)));
            }

            public static FileDbRepository<TEntity, TIdentifier> Create(PathValue endpoint, FileType fileType, EncodingValue encoding)
            {
                return new FileDbRepository<TEntity, TIdentifier>(new FileClient(endpoint, encoding, AccessType.Create(fileType)));
            }
        }

        #endregion constructor

        #region method

        /// <inheritdoc />
        public async Task<IEnumerable<TEntity>> GetsAsync()
        {
            return await _client.GetsAsync<TEntity>("");
        }

        /// <inheritdoc />
        public async Task<TEntity> GetAsync(TIdentifier identifier)
        {
            var items = await GetsAsync();
            return items.FirstOrDefault(x => x.Id.Equals(identifier));
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

        /// <inheritdoc />
        public async Task<ResponseStatus> DeleteAsync(TEntity entity)
        {
            return await _client.DeleteAsync("", entity);
        }

        #endregion method
    }
}