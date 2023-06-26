using Mov.Accessors;
using Mov.Accessors.Contexts;
using Mov.Accessors.Services.Serializer.Implements;
using Mov.Repositories.Models.EntityObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Repositories.Services.Entities
{
    public class RestEntityRepository<TEntity> : IEntityRepositoryAsync<TEntity>
    {
        private readonly HttpSerializer serializer;
        private readonly string key;

        public RestEntityRepository(string url, string key, string encode = AccessConstants.ENCODE_NAME_UTF8)
        {
            serializer = new HttpSerializer(new FileAccessContext(url, encode));
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
