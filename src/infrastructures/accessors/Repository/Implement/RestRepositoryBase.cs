using Mov.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public abstract class RestRepositoryBase<T> : IRepository
    {
        private readonly HttpSerializer serializer;
        private readonly string key;

        public RestRepositoryBase(string url, string key, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            this.serializer = new HttpSerializer(url, encode);
            this.key = "?apikey=" + key;
        }

        public async Task<IEnumerable<T>> GetAsync() =>
            await this.serializer.GetAsync<IEnumerable<T>>(this.key);

        public async Task<T> GetAsync(string date) =>
           await this.serializer.GetAsync<T>($"/{date}" + this.key);

        public async Task PostAsync(T item) =>
            await this.serializer.PostAsync<T, T>(this.key, item);

        public Task PostAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}
