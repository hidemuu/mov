using Mov.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public class RestRepository<T> : IRepository<T>
    {
        private readonly HttpSerializer serializer;
        private readonly string key;

        public RestRepository(string url, string key, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            this.serializer = new HttpSerializer(url, encode);
            this.key = string.IsNullOrEmpty(key) ? string.Empty : "?apikey=" + key;
        }

        public async Task<IEnumerable<T>> GetAsync() =>
            await this.serializer.GetAsync<IEnumerable<T>>(this.key);

        public async Task<T> GetAsync(string param) =>
           await this.serializer.GetAsync<T>($"/{param}" + this.key);

        public async Task PostAsync(T item) =>
            await this.serializer.PostAsync<T, T>(this.key, item);

        public Task PostAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}
