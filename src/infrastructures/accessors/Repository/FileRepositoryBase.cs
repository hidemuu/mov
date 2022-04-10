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
    public abstract class FileRepositoryBase<T, C> where T : DbObject where C : DbObjectCollection<T>
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

        public IEnumerable<T> Gets() => fileSerializer.Read<C>().Items;
        
        public async Task<IEnumerable<T>> GetsAsync() => await Task.Run(Gets);
        
        public T Get() => fileSerializer.Read<T>();
        
        public async Task<T> GetAsync() => await Task.Run(Get);
        
        public T Get(int id) => Gets().FirstOrDefault(x => x.Id == id);

        public T Get(string code) => Gets().FirstOrDefault(x => x.Code == code);

        public override string ToString()
        {
            var items = Gets();
            if (items == null) return string.Empty;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(">> ").AppendLine(typeof(T).Name);
            GetStringTables(items.ToList(), stringBuilder);
            return stringBuilder.ToString();
        }

        #endregion

        #region 内部メソッド

        private void GetStringTables(List<T> items, StringBuilder stringBuilder)
        {
            bool isWightedHeader = false;
            foreach (var item in items)
            {
                if (!isWightedHeader) 
                {
                    var header = item.ToStringTableHeader();
                    stringBuilder.AppendLine(header);
                    for(int i = 0; i < header.Length; i++)
                    {
                        stringBuilder.Append("-");
                    }
                    stringBuilder.AppendLine();
                    isWightedHeader = true;
                }
                if (item is DbObjectNode<T> node)
                {
                    stringBuilder.AppendLine(node.ToStringTables());
                    continue;
                }
                stringBuilder.AppendLine(item.ToStringTable());
            }
        }

        #endregion
    }
}
