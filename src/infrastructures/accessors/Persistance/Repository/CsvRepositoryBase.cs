using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public abstract class CsvRepositoryBase<T> : IRepository
    {
        private readonly CsvSerializer serializer;

        public CsvRepositoryBase(string fileName, string encode = "utf-8")
        {
            serializer = new CsvSerializer(fileName, "", encode);
        }

        public async Task<T> GetAsync()
        {
            return await Task.Run(() => serializer.Read<T>());
        }

        public async Task PostAsync(T item)
        {
            await Task.Run(() => serializer.Write<T>(item));
        }

        public async Task PostAsync(IEnumerable<T> items)
        {
            await Task.Run(async () =>
            {
                foreach (var item in items)
                {
                    await PostAsync(item);
                }
            });
        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
