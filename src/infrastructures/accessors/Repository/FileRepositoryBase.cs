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

        /// <summary>
        /// シリアライザー
        /// </summary>
        protected readonly ISerializer fileSerializer;

        /// <summary>
        /// 内部保持変数
        /// </summary>
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

        /// <summary>
        /// インポート
        /// </summary>
        public void Import() => collection = fileSerializer.Read<C>();       

        /// <summary>
        /// エクスポート
        /// </summary>
        public void Export() => fileSerializer.Write<C>(this.collection);

        /// <summary>
        /// 単一データエクスポート
        /// </summary>
        /// <param name="item"></param>
        public void Export(T item) => fileSerializer.Write<T>(item);

        #region GET

        public IEnumerable<T> Gets() 
        { 
            if(collection == null) Import();
            return collection.Items;
        }
        
        public async Task<IEnumerable<T>> GetsAsync() => await Task.Run(Gets);

        public T Get(Guid id) => Gets().FirstOrDefault(x => x.Id == id);

        public T Get(int index) => Gets().FirstOrDefault(x => x.Index == index);

        public T Get(string code) => Gets().FirstOrDefault(x => x.Code == code);

        #endregion GET

        #region POST

        public void Posts(IEnumerable<T> items)
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

        public void Post(T item) 
        {
            var src = collection.Items.FirstOrDefault(x => x.Id == item.Id);
            src = item;
        }

        #endregion POST

        #region PUT

        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="item"></param>
        public void Put(T item)
        {
            collection.Items.ToList().Add(item);
        }

        /// <summary>
        /// データ追加（位置指定）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        public void Put(Guid id, T item)
        {
            var src = collection.Items.FirstOrDefault(x => x.Id == id);
            if(src is DbObjectNode<T> node)
            {
                node.Children.Add(item);
                return;
            }
            Put(item);
        }

        #endregion PUT

        #region DELETE

        /// <summary>
        /// データ削除
        /// </summary>
        /// <param name="item"></param>
        public void Delete(T item)
        {
            collection.Items.ToList().Remove(item);
        }

        #endregion DELETE

        #region MOVE

        /// <summary>
        /// データ移動
        /// </summary>
        /// <param name="id">移動元ID</param>
        /// <param name="movedId">移動先ID</param>
        public void Move(Guid id, Guid movedId)
        {
            var src = collection.Items.FirstOrDefault(x => x.Id == id);
            if (src == null) return;
            var moved = collection.Items.FirstOrDefault(x => x.Id == movedId);
            if (moved == null) return;

        }

        #endregion MOVE

        /// <inheritdoc />
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

        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
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
