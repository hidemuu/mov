using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.DbObjects
{
    public class RestDbObjectRepository<TEntity, TKey> : IDbObjectRepository<TEntity, TKey>
        where TEntity : IDbObject<TKey>
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

        public RestDbObjectRepository(IClient client, string key)
        {
            this._client = client;
            this._key = string.IsNullOrEmpty(key) ? string.Empty : API_KEY + key;
        }

        public RestDbObjectRepository(string url, string key, EncodingValue encode)
            : this(new WebClient(new PathValue(url), encode), key)
        {
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetAsync() =>
            await _client.GetAsync<TEntity>(_key);

        public async Task<TEntity> GetAsync(TKey param)
        {
            var items = await _client.GetAsync<TEntity>($"/{param}" + _key);
            return items.FirstOrDefault(x => x.Id.Equals(param));
        }


        public async Task PostAsync(TEntity item) =>
            await _client.PostAsync(_key, item);

        public Task PostAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
