using Mov.Core.Accessors;
using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Models;
using System;
using System.Collections.Generic;
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

        private readonly HttpSerializer serializer;
        private readonly string key;

        #endregion field

        #region constructor

        public RestDbObjectRepository(string url, string key, EncodingValue encode)
        {
            this.serializer = new HttpSerializer(new PathValue(url), encode);
            this.key = string.IsNullOrEmpty(key) ? string.Empty : API_KEY + key;
        }

        #endregion constructor

        #region method

        public async Task<IEnumerable<TEntity>> GetAsync() =>
            await this.serializer.GetAsync<IEnumerable<TEntity>>(this.key);

        public async Task<TEntity> GetAsync(TKey param) =>
           await this.serializer.GetAsync<TEntity>($"/{param}" + this.key);

        public async Task PostAsync(TEntity item) =>
            await this.serializer.PostAsync<TEntity, TEntity>(this.key, item);

        public Task PostAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        #endregion method
    }
}
