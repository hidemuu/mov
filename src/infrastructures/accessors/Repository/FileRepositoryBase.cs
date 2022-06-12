using Mov.Accessors;
using Mov.Accessors.Repository;
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
    public abstract class FileRepositoryBase<T, C> : IRepository<T> where T : DbObject where C : DbObjectCollection<T>
    {
        #region 定数

        private const string PATH_EXTENSION_JSON = ".json";

        private const string PATH_EXTENSION_XML = ".xml";

        private const string PATH_EXTENSION_CSV = ".csv";

        private const string PATH_EXTENSION_SQL = ".db";

        #endregion

        #region フィールド

        protected readonly ISerializer fileSerializer;

        private C collection = null;

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileRepositoryBase(string path, string encoding = DbConstants.ENCODE_NAME_UTF8)
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

        #region GET

        public IEnumerable<T> Gets() 
        { 
            if(collection == null) collection = fileSerializer.Read<C>();
            return collection.Items;
        }
        
        public async Task<IEnumerable<T>> GetsAsync() => await Task.Run(Gets);

        public T Get(Guid id) => Gets().FirstOrDefault(x => x.Id == id);

        public T Get(int index) => Gets().FirstOrDefault(x => x.Index == index);

        public T Get(string code) => Gets().FirstOrDefault(x => x.Code == code);

        #endregion GET

        #region SET

        public void Sets(IEnumerable<T> items)
        {
            List<T> srcs = collection.Items.ToList();
            foreach (var item in items)
            {
                var src = srcs.FirstOrDefault(x => x.Code == item.Code);
                if (src != null) srcs.Remove(src);
                srcs.Add(item);
            }
            collection.Items = srcs.ToArray();
        }

        public void Set(T item)
        {
            var src = collection.Items.FirstOrDefault(x => x.Id == item.Id);
            src = item;
        }

        #endregion SET

        #region POST

        public void Posts() => fileSerializer.Write<C>(this.collection);

        public void Post(T item) 
        {
            Set(item);
            fileSerializer.Write<T>(item);
        }

        #endregion POST

        public override string ToString()
        {
            var items = Gets();
            if (items == null) return string.Empty;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(">> ").AppendLine(typeof(T).Name);
            GetStringTables(items.ToList(), stringBuilder);
            return stringBuilder.ToString();
        }

        #endregion メソッド

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

        #endregion 内部メソッド
    }
}
