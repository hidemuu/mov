using Mov.Core.Accessors;
using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Clients;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Implements.DbObjects
{
    public class RestDbObjectRepository<TEntity, TKey> : IDbObjectRepository<TEntity, TKey> 
        where TEntity : IDbObject<TKey>
    {
        #region constant

        private const string API_KEY = "?apikey=";

        #endregion constant

        #region field

        private readonly IClient client;

        private readonly string key;

        #endregion field

        #region constructor

        public RestDbObjectRepository(IClient client, string key)
        {
            this.client = client;
            this.key = string.IsNullOrEmpty(key) ? string.Empty : API_KEY + key;
        }

        public RestDbObjectRepository(string url, string key, EncodingValue encode) 
            : this(new WebClient(new PathValue(url), encode), key)
        {
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetAsync() =>
            await this.client.GetAsync<TEntity>(this.key);

        public async Task<TEntity> GetAsync(TKey param)
        {
            var items= await this.client.GetAsync<TEntity>($"/{param}" + this.key);
            return items.FirstOrDefault(x => x.Id.Equals(param));
        }
           

        public async Task PostAsync(TEntity item) =>
            await this.client.PostAsync(this.key, item);

        public Task PostAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
