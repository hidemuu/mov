using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories.Schemas.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Services
{
    public class RestDbRepository<TEntity, TIdentifier, TRequest> : IDbRepository<TEntity, TIdentifier, TRequest>
        where TEntity : IDbSchema<TIdentifier>
        where TRequest : IDbRequestSchema
    {
        #region constant

        private const string PARAMETER_KEY = "?";

        #endregion constant

        #region field

        private readonly IClient _client;

        private readonly string _additionalUri;

        #endregion field

        #region property

        public string Endpoint => _client.Endpoint.Value;

        #endregion property

        #region constructor

        public RestDbRepository(IClient client, string additionalUri)
        {
            _client = client;
			_additionalUri = additionalUri;
        }

        public RestDbRepository(string url, EncodingValue encode, IReadOnlyDictionary<string, string> headers)
            : this(new WebClient(new PathValue(url), encode, headers), string.Empty)
        {
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetsAsync() =>
            await _client.GetsAsync<TEntity>(_additionalUri);

        public async Task<TEntity> GetAsync(TIdentifier identidfier)
        {
            if(identidfier == null)
            {
                return await _client.GetAsync<TEntity>(_additionalUri);
            }
            var entities = await _client.GetsAsync<TEntity>($"{_additionalUri}/{identidfier}");
            return entities.FirstOrDefault(x => x.Id.Equals(identidfier));
        }

		public async Task<TEntity> GetRequestAsync(TRequest request)
		{
            if(request is DbRequestSchemaNull)
            {
                return await _client.GetAsync<TEntity>(_additionalUri);
			}
			return await _client.GetAsync<TEntity>($"{_additionalUri}{PARAMETER_KEY}{request.Uri}");
		}

		public async Task<ResponseStatus> PostsAsync(IEnumerable<TEntity> entities)
		{
			return await _client.PostAsync(_additionalUri, entities);
		}

		public async Task<ResponseStatus> PostAsync(TEntity entity)
        {
            return await _client.PostAsync(_additionalUri, entity);
        }

        public async Task<ResponseStatus> PutAsync(TEntity entity)
        {
            return await _client.PutAsync(_additionalUri, entity);
        }

        public async Task<ResponseStatus> DeleteAsync(TEntity entity)
        {
            return await _client.DeleteAsync(_additionalUri, entity.Id);
        }

        public async Task<ResponseStatus> DeleteAsync(TIdentifier identifier)
        {
            return await _client.DeleteAsync(_additionalUri, identifier);
        }

		#endregion method
	}
}
