using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public abstract class JsonRepositoryBase<T> : IRepository
    {
        private readonly JsonSerializer serializer;

        public JsonRepositoryBase(string fileName, string encode = "utf-8")
        {
            serializer = new JsonSerializer(fileName, encode);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() => serializer.Get<IEnumerable<T>>(""));
        }

        public async Task PostAsync(T item)
        {
            await Task.Run(() => serializer.Post<T, T>("", item));
        }

        public async Task PostAsync(IEnumerable<T> items)
        {
            await Task.Run(() => serializer.Post<IEnumerable<T>, IEnumerable<T>>("", items));

        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
