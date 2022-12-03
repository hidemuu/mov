using Mov.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public class RestEntityRepository<TEntity> : IEntityRepositoryAsync<TEntity>
    {
        private readonly HttpSerializer serializer;
        private readonly string key;

        public RestEntityRepository(string url, string key, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            this.serializer = new HttpSerializer(url, encode);
            this.key = string.IsNullOrEmpty(key) ? string.Empty : "?apikey=" + key;
        }

        public async Task<IEnumerable<TEntity>> GetAsync() =>
            await this.serializer.GetAsync<IEnumerable<TEntity>>(this.key);

        public async Task<TEntity> GetAsync(string param) =>
           await this.serializer.GetAsync<TEntity>($"/{param}" + this.key);

        public async Task PostAsync(TEntity item) =>
            await this.serializer.PostAsync<TEntity, TEntity>(this.key, item);

        public Task PostAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }
    }
}
