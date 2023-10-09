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

        private readonly string _key;

        #endregion field

        #region property

        public string Endpoint => _client.Endpoint.Value;

        #endregion property

        #region constructor

        public RestDbRepository(IClient client, string key)
        {
            _client = client;
            _key = string.IsNullOrEmpty(key) ? string.Empty : API_KEY + key;
        }

        public RestDbRepository(string url, string key, EncodingValue encode, IReadOnlyDictionary<string, string> headers)
            : this(new WebClient(new PathValue(url), encode, headers), key)
        {
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetsAsync() =>
            await _client.GetsAsync<TEntity>(_key);

        public async Task<TEntity> GetAsync(TIdentifier identidfier)
        {
            var entities = await _client.GetsAsync<TEntity>($"/{identidfier}" + _key);
            return entities.FirstOrDefault(x => x.Id.Equals(identidfier));
        }


        public async Task<ResponseStatus> PostAsync(TEntity entity)
        {
            return await _client.PostAsync(_key, entity);
        }

        public async Task<ResponseStatus> PutAsync(TEntity entity)
        {
            return await _client.PutAsync(_key, entity);
        }

        public async Task<ResponseStatus> DeleteAsync(TEntity entity)
        {
            return await _client.DeleteAsync(_key, entity.Id);
        }

        public async Task<ResponseStatus> DeleteAsync(TIdentifier identifier)
        {
            return await _client.DeleteAsync(_key, identifier);
        }

        #endregion method
    }
}
