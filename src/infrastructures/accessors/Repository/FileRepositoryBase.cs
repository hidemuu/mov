using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    /// <summary>
    /// ファイルリポジトリ基本クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FileRepositoryBase<T> where T : DatabaseObject
    {
        #region 定数

        private const string PATH_EXTENSION_JSON = ".json";

        private const string PATH_EXTENSION_XML = ".xml";

        private const string PATH_EXTENSION_CSV = ".csv";

        private const string PATH_EXTENSION_SQL = ".db";

        #endregion

        #region フィールド

        protected readonly IFileSerializer fileSerializer;

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileRepositoryBase(string path, string encoding = "utf-8")
        {
            var extension = System.IO.Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension)) Debug.Assert(false);

            switch (extension)
            {
                case PATH_EXTENSION_JSON:
                    this.fileSerializer = new JsonFileSerializer(path, encoding);
                    break;
                case PATH_EXTENSION_XML:
                    this.fileSerializer = new XmlFileSerializer(path, encoding);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }

        #region メソッド

        public virtual IEnumerable<T> Gets() => fileSerializer.Read<IEnumerable<T>>();
        
        public async Task<IEnumerable<T>> GetsAsync() => await Task.Run(Gets);
        
        public virtual T Get() => fileSerializer.Read<T>();
        
        public async Task<T> GetAsync() => await Task.Run(Get);
        
        public T Get(int id) => Gets().FirstOrDefault(x => x.Id == id);

        public T Get(string code) => Gets().FirstOrDefault(x => x.Code == code);

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach(var item in Gets())
            {
                stringBuilder.AppendLine(item.ToString());
            }
            return stringBuilder.ToString();
        }

        #endregion
    }
}
