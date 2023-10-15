using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
    public class RestDbRepository<TEntity, TIdentifier> : IDbRepository<TEntity, TIdentifier>
        where TEntity : IDbSchema<TIdentifier>
    {
        #region constant

        private const string API_KEY = "?apikey=";

        #endregion constant

        #region field

        private readonly IClient _client;

        private readonly string _request;

        #endregion field

        #region property

        public string Endpoint => _client.Endpoint.Value;

        #endregion property

        #region constructor

        public RestDbRepository(IClient client, string request)
        {
            _client = client;
            _request = request;
        }

        public RestDbRepository(string url, string request, EncodingValue encode, IReadOnlyDictionary<string, string> headers)
            : this(new WebClient(new PathValue(url), encode, headers), request)
        {
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetsAsync() =>
            await _client.GetsAsync<TEntity>(_request);

        public async Task<TEntity> GetAsync(TIdentifier identidfier)
        {
            if(identidfier == null)
            {
                return await _client.GetAsync<TEntity>(_request);
            }
            var entities = await _client.GetsAsync<TEntity>($"/{identidfier}" + _request);
            return entities.FirstOrDefault(x => x.Id.Equals(identidfier));
        }

		public async Task<ResponseStatus> PostsAsync(IEnumerable<TEntity> entities)
		{
			return await _client.PostAsync(_request, entities);
		}

		public async Task<ResponseStatus> PostAsync(TEntity entity)
        {
            return await _client.PostAsync(_request, entity);
        }

        public async Task<ResponseStatus> PutAsync(TEntity entity)
        {
            return await _client.PutAsync(_request, entity);
        }

        public async Task<ResponseStatus> DeleteAsync(TEntity entity)
        {
            return await _client.DeleteAsync(_request, entity.Id);
        }

        public async Task<ResponseStatus> DeleteAsync(TIdentifier identifier)
        {
            return await _client.DeleteAsync(_request, identifier);
        }

        #endregion method
    }
}
