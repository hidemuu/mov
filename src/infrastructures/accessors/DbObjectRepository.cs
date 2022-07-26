using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    /// <summary>
    /// データベースリポジトリ基本クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbObjectRepository<T, C> : IDbObjectRepository<T> where T : DbObject where C : DbObjectCollection<T>
    {
       
        #region フィールド

        /// <summary>
        /// シリアライザー
        /// </summary>
        protected readonly ISerializer serializer;

        /// <summary>
        /// 内部保持変数
        /// </summary>
        private C collection = null;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DbObjectRepository(string basePath, string relativePath, string encoding)
        {
            var extension = System.IO.Path.GetExtension(relativePath);
            if (string.IsNullOrEmpty(extension)) Debug.Assert(false);

            switch (extension)
            {
                case DbConstants.PATH_EXTENSION_JSON:
                    this.serializer = new JsonFileSerializer(basePath, relativePath, encoding);
                    break;

                case DbConstants.PATH_EXTENSION_XML:
                    this.serializer = new XmlFileSerializer(basePath, relativePath, encoding);
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
        public void Import() => collection = serializer.Read<C>();

        /// <summary>
        /// エクスポート
        /// </summary>
        public void Export() => serializer.Write<C>(this.collection);

        /// <summary>
        /// 単一データエクスポート
        /// </summary>
        /// <param name="item"></param>
        public void Export(T item) => serializer.Write<T>(item);

        #region GET

        /// <summary>
        /// 全データ取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Gets()
        {
            if (collection == null) Import();
            return collection.Items;
        }

        /// <summary>
        /// 全データ取得（非同期）
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetsAsync() => await Task.Run(Gets);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(Guid id) => Get(Gets(), id);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index) => Get(Gets(), index);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public T Get(string code) => Get(Gets(), code);

        #endregion GET

        #region POST

        /// <summary>
        /// 全データ追加・更新
        /// </summary>
        /// <param name="items"></param>
        public void Posts(IEnumerable<T> items)
        {
            List<T> srcs = Gets().ToList();
            foreach (var item in items)
            {
                var src = srcs.FirstOrDefault(x => x.Id == item.Id);
                //一致するものがある場合は、一旦消す
                if (src != null) srcs.Remove(src);
                //追加
                srcs.Add(item);
            }
            collection.Items = srcs.ToArray();
        }

        /// <summary>
        /// データ追加・更新
        /// </summary>
        /// <param name="item"></param>
        public void Post(T item)
        {
            var src = Gets().FirstOrDefault(x => x.Id == item.Id);
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
            var items = Gets().ToList();
            items.Add(item);
            collection.Items = items.ToArray();
        }

        /// <summary>
        /// データ追加（位置指定）
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        public void Put(T item, Guid id)
        {
            if (item is DbObjectNode<T>)
            {
                var src = Get(Gets(), id);
                if (src == null) return;
                if (src is DbObjectNode<T> node)
                {
                    node.Children.Add(item);
                    return;
                }
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
            var srcs = Gets().ToList();
            Remove(srcs, item);
            collection.Items = srcs.ToArray();
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
            var src = Gets().FirstOrDefault(x => x.Id == id);
            if (src == null) return;
            var moved = Gets().FirstOrDefault(x => x.Id == movedId);
            if (moved == null) return;
            if (src is DbObjectNode<T> srcNode)
            {
                if (!(moved is DbObjectNode<T> movedNode)) return;
                var srcNodeClone = new DbObjectNode<T>(srcNode);
                srcNode = new DbObjectNode<T>(movedNode);
                movedNode = new DbObjectNode<T>(srcNodeClone);
            }
            else if (src is DbObject srcObject)
            {
                if (!(moved is DbObject movedObject)) return;
                var srcObjectClone = new DbObject(srcObject);
                srcObject = new DbObject(movedObject);
                movedObject = new DbObject(srcObjectClone);
            }
        }

        public void MovePrev(Guid id)
        {
            var arrayIndex = GetArrayIndex(id);
            var movedIndex = arrayIndex - 1;
            if (movedIndex < 0) return;
            var items = Gets().ToArray();
            var src = items[arrayIndex];
            var moved = items[movedIndex];
            var querys = Gets().ToArray();
            querys[arrayIndex] = moved;
            querys[movedIndex] = src;
            collection.Items = querys;
        }

        public void MoveNext(Guid id)
        {
            var arrayIndex = GetArrayIndex(id);
            var movedIndex = arrayIndex + 1;
            if (movedIndex > collection.Items.Length) return;
            var items = Gets().ToArray();
            var src = items[arrayIndex];
            var moved = items[movedIndex];
            var querys = Gets().ToArray();
            querys[arrayIndex] = moved;
            querys[movedIndex] = src;
            collection.Items = querys;
        }

        private int GetArrayIndex(Guid id)
        {
            var items = Gets().ToArray();
            for (int i = 0; i < items.Length; i++)
            {
                if (!items[i].Id.Equals(id)) continue;
                return i;
            }
            return -1;
        }

        #endregion MOVE

        /// <inheritdoc />
        public override string ToString()
        {
            var items = Gets();
            if (items == null) return string.Empty;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(">> ").AppendLine(typeof(T).Name);
            GetStrings(items.ToList(), stringBuilder);
            return stringBuilder.ToString();
        }

        #endregion メソッド

        #region 内部メソッド

        private T Get(IEnumerable<T> items, object key)
        {
            T item = null;
            if (key is Guid id) item = items.FirstOrDefault(x => x.Id == id);
            if (key is int index) item = items.FirstOrDefault(x => x.Index == index);
            if (key is string code) item = items.FirstOrDefault(x => x.Code == code);
            if (item != null) return item;
            if (!(items is IEnumerable<DbObjectNode<T>> nodes)) return item;
            foreach (var node in nodes)
            {
                item = Get(node.Children, key);
                if (item != null) return item;
            }
            return item;
        }

        private void Remove(ICollection<T> items, T item)
        {
            var isSuccess = items.Remove(item);
            if (items is IEnumerable<DbObjectNode<T>> nodes)
            {
                foreach (var node in nodes)
                {
                    Remove(node.Children, item);
                }
            }
        }

        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
        private void GetStrings(List<T> items, StringBuilder stringBuilder)
        {
            bool isWightedHeader = false;
            foreach (var item in items)
            {
                if (!isWightedHeader)
                {
                    var header = item.ToHeaderString();
                    stringBuilder.AppendLine(header);
                    for (int i = 0; i < header.Length; i++)
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
                stringBuilder.AppendLine(item.ToContentString());
            }
        }

        #endregion 内部メソッド
    }
}