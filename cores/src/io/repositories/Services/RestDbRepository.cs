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

        public RestDbRepository(string url, string key, EncodingValue encode)
            : this(new WebClient(new PathValue(url), encode), key)
        {
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetAsync() =>
            await _client.GetAsync<TEntity>(_key);

        public async Task<TEntity> GetAsync(TIdentifier identidfier)
        {
            var entities = await _client.GetAsync<TEntity>($"/{identidfier}" + _key);
            return entities.FirstOrDefault(x => x.Id.Equals(identidfier));
        }


        public async Task PostAsync(TEntity entity)
        {
            await _client.PostAsync(_key, entity);
        }

        public async Task PutAsync(TEntity entity)
        {
            await _client.PutAsync(_key, entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _client.DeleteAsync(_key, entity.Id);
        }

        public async Task DeleteAsync(TIdentifier identifier)
        {
            await _client.DeleteAsync(_key, identifier);
        }

        #endregion method
    }
}
