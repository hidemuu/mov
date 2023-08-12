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
        private readonly HttpSerializer serializer;
        private readonly string key;

        public RestDbObjectRepository(string url, string key, EncodingValue encode)
        {
            serializer = new HttpSerializer(new PathValue(url), encode);
            this.key = string.IsNullOrEmpty(key) ? string.Empty : "?apikey=" + key;
        }

        public async Task<IEnumerable<TEntity>> GetAsync() =>
            await serializer.GetAsync<IEnumerable<TEntity>>(key);

        public async Task<TEntity> GetAsync(string param) =>
           await serializer.GetAsync<TEntity>($"/{param}" + key);

        public async Task PostAsync(TEntity item) =>
            await serializer.PostAsync<TEntity, TEntity>(key, item);

        public Task PostAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }
    }
}
