using Mov.Accessors.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    public class FileEntityRepository<TEntity, TBody> : IEntityRepositoryAsync<TEntity>, IFileRepository<TBody>
    {
        protected readonly ISerializer serializer;

        protected TBody body = default;

        public FileEntityRepository(string fileName, string encode = SerializeConstants.ENCODE_NAME_UTF8)
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
                case SerializeConstants.PATH_EXTENSION_CSV:
                    this.serializer = new CsvSerializer(fileName, encode);
                    break;
                default:
                    Debug.Assert(false, "拡張子が不正です");
                    break;
            }
        }

        /// <summary>
        /// インポート
        /// </summary>
        public TBody Read() 
        { 
            this.body = serializer.Get<TBody>("");
            return this.body;
        }

        /// <summary>
        /// エクスポート
        /// </summary>
        public void Write() => serializer.Post<TBody, TBody>("", this.body);

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await Task.Run(() => serializer.Get<IEnumerable<TEntity>>(""));
        }

        public async Task<TEntity> GetAsync(string param)
        {
            return await Task.Run(() => serializer.Get<TEntity>(param));
        }

        public async Task PostAsync(TEntity item)
        {
            await Task.Run(() => serializer.Post<TEntity, TEntity>("", item));
        }

        public async Task PostAsync(IEnumerable<TEntity> items)
        {
            await Task.Run(() => serializer.Post<IEnumerable<TEntity>, IEnumerable<TEntity>>("", items));

        }

        public Task DeleteAsync(string date)
        {
            throw new NotImplementedException();
        }
    }
}
