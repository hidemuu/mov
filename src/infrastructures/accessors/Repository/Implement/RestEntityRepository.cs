using Mov.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public class RestEntityRepository<TModel> : IEntityRepository<TModel>
    {
        private readonly HttpSerializer serializer;
        private readonly string key;

        public RestEntityRepository(string url, string key, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            this.serializer = new HttpSerializer(url, encode);
            this.key = string.IsNullOrEmpty(key) ? string.Empty : "?apikey=" + key;
        }

        public async Task<IEnumerable<TModel>> GetAsync() =>
            await this.serializer.GetAsync<IEnumerable<TModel>>(this.key);

        public async Task<TModel> GetAsync(string param) =>
           await this.serializer.GetAsync<TModel>($"/{param}" + this.key);

        public async Task PostAsync(TModel item) =>
            await this.serializer.PostAsync<TModel, TModel>(this.key, item);

        public Task PostAsync(IEnumerable<TModel> items)
        {
            throw new NotImplementedException();
        }
    }
}
