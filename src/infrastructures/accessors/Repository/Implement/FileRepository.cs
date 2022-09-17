using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public abstract class FileRepository<T> : IRepository
    {
        private readonly ISerializer serializer;

        public FileRepository(string fileName, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            var extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(extension)) Debug.Assert(false, "拡張子が含まれていません");
            switch (extension)
            {
                case SerializeConstants.PATH_EXTENSION_JSON:
                    this.serializer = new JsonSerializer(fileName, encode);
                    break;

                case SerializeConstants.PATH_EXTENSION_XML:
                    this.serializer = new XmlSerializer(fileName, encode);
                    break;

                default:
                    Debug.Assert(false, "拡張子が不正です");
                    break;
            }
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
