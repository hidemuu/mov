using Mov.Accessors.Serializer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Analizer.Repository.Resas
{
    public class RestResasRepositoryBase<T>
    {
        private readonly HttpSerializer http;
        private readonly string key;
        private readonly string root;

        public RestResasRepositoryBase(string url, string key, string root)
        {
            this.http = new HttpSerializer(url);
            this.key = "?apikey=" + key;
            this.root = root;
        }

        public async Task<IEnumerable<T>> GetAsync() =>
            await this.http.GetAsync<IEnumerable<T>>(this.root + this.key);

        public async Task<T> GetAsync(string date) =>
           await this.http.GetAsync<T>(root + $"/{date}" + this.key);

        public async Task PostAsync(T item) =>
            await this.http.PostAsync<T, T>(this.root + this.key, item);

        public Task PostAsync(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }
    }
}
