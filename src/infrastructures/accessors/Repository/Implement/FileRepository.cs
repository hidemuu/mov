using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public abstract class FileRepository<TModel> : IRepository<TModel>
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

        public async Task<IEnumerable<TModel>> GetAsync()
        {
            return await Task.Run(() => serializer.Get<IEnumerable<TModel>>(""));
        }

        public async Task<TModel> GetAsync(string param)
        {
            return await Task.Run(() => serializer.Get<TModel>(param));
        }

        public async Task PostAsync(TModel item)
        {
            await Task.Run(() => serializer.Post<TModel, TModel>("", item));
        }

        public async Task PostAsync(IEnumerable<TModel> items)
        {
            await Task.Run(() => serializer.Post<IEnumerable<TModel>, IEnumerable<TModel>>("", items));

        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
