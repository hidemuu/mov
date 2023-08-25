using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Clients;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Services.Serializer.FIles;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Repositories.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Implements.DbTables
{
    /// <summary>
    /// データベースリポジトリ基本クラス
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class FileDbTableRepository<TEntity, TBody>
        : FileDbObjectRepository<TEntity, Guid>, IDbTableRepository<TEntity>
        where TEntity : DbTable
        where TBody : DbTableCollection<TEntity, Guid>
    {
        #region フィールド

        protected TBody body = default;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDbTableRepository(string fileName, EncodingValue encoding, FileType fileType)
            : base(new FileClient(new PathValue(fileName), encoding, AccessType.Create(fileType)))
        {

        }

        #region メソッド


        #region GET

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(Guid id)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            return Get(task.Result, id);
        }


        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TEntity Get(int index) 
        {
            var task = GetAsync();
            Task.WaitAll(task);
            return Get(task.Result, index);
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public TEntity Get(string code) 
        {
            var task = GetAsync();
            Task.WaitAll(task);
            return Get(task.Result, code);
        }

        #endregion GET

        #region POST

        /// <summary>
        /// 全データ追加・更新
        /// </summary>
        /// <param name="items"></param>
        public void Posts(IEnumerable<TEntity> items)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            List<TEntity> srcs = task.Result.ToList();
            foreach (var item in items)
            {
                var src = srcs.FirstOrDefault(x => x.Id == item.Id);
                //一致するものがある場合は、一旦消す
                if (src != null) srcs.Remove(src);
                //追加
                srcs.Add(item);
            }
            if (!srcs.Any()) return;
            body.Items = srcs.ToArray();
        }

        /// <summary>
        /// データ追加・更新
        /// </summary>
        /// <param name="item"></param>
        public void Post(TEntity item)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            var src = task.Result.FirstOrDefault(x => x.Id == item.Id);
            src = item;
        }

        #endregion POST

        #region PUT

        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="item"></param>
        public void Put(TEntity item)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            var items = task.Result.ToList();
            items.Add(item);
            if (body == default) body = (TBody)Activator.CreateInstance(typeof(TBody));
            body.Items = items.ToArray();
        }

        /// <summary>
        /// データ追加（位置指定）
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        public void Put(TEntity item, Guid id)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            if (item is DbTableNode<TEntity>)
            {
                var src = Get(task.Result, id);
                if (src == null) return;
                if (src is DbTableNode<TEntity> node)
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
        public void Delete(TEntity item)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            var srcs = task.Result.ToList();
            Remove(srcs, item);
            body.Items = srcs.ToArray();
        }

        public void Delete(Guid id)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            var srcs = task.Result.ToList();
            Remove(srcs, Get(id));
            body.Items = srcs.ToArray();
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
            var task = GetAsync();
            Task.WaitAll(task);
            var src = task.Result.FirstOrDefault(x => x.Id == id);
            if (src == null) return;
            var moved = task.Result.FirstOrDefault(x => x.Id == movedId);
            if (moved == null) return;
            if (src is DbTableNode<TEntity> srcNode)
            {
                if (!(moved is DbTableNode<TEntity> movedNode)) return;
                var srcNodeClone = new DbTableNode<TEntity>(srcNode);
                srcNode = new DbTableNode<TEntity>(movedNode);
                movedNode = new DbTableNode<TEntity>(srcNodeClone);
            }
            else if (src is DbTable srcObject)
            {
                if (!(moved is DbTable movedObject)) return;
                var srcObjectClone = new DbTable(srcObject);
                srcObject = new DbTable(movedObject);
                movedObject = new DbTable(srcObjectClone);
            }
        }

        public void MovePrev(Guid id)
        {
            var arrayIndex = GetArrayIndex(id);
            var movedIndex = arrayIndex - 1;
            if (movedIndex < 0) return;
            var task = GetAsync();
            Task.WaitAll(task);
            var items = task.Result.ToArray();
            var src = items[arrayIndex];
            var moved = items[movedIndex];
            var querys = task.Result.ToArray();
            querys[arrayIndex] = moved;
            querys[movedIndex] = src;
            body.Items = querys;
        }

        public void MoveNext(Guid id)
        {
            var arrayIndex = GetArrayIndex(id);
            var movedIndex = arrayIndex + 1;
            if (movedIndex > body.Items.Length) return;
            var task = GetAsync();
            Task.WaitAll(task);
            var items = task.Result.ToArray();
            var src = items[arrayIndex];
            var moved = items[movedIndex];
            var querys = task.Result.ToArray();
            querys[arrayIndex] = moved;
            querys[movedIndex] = src;
            body.Items = querys;
        }

        private int GetArrayIndex(Guid id)
        {
            var task = GetAsync();
            Task.WaitAll(task);
            var items = task.Result.ToArray();
            for (int i = 0; i < items.Length; i++)
            {
                if (!items[i].Id.Equals(id)) continue;
                return i;
            }
            return -1;
        }

        #endregion MOVE

        #endregion メソッド

        #region 内部メソッド

        private TEntity Get(IEnumerable<TEntity> items, object key)
        {
            TEntity item = null;
            if (key is Guid id) item = items.FirstOrDefault(x => x.Id == id);
            if (key is int index) item = items.FirstOrDefault(x => x.Index == index);
            if (key is string code) item = items.FirstOrDefault(x => x.Code == code);
            if (item != null) return item;
            if (!(items is IEnumerable<DbTableNode<TEntity>> nodes)) return item;
            foreach (var node in nodes)
            {
                item = Get(node.Children, key);
                if (item != null) return item;
            }
            return item;
        }

        private void Remove(ICollection<TEntity> items, TEntity item)
        {
            var isSuccess = items.Remove(item);
            if (items is IEnumerable<DbTableNode<TEntity>> nodes)
            {
                foreach (var node in nodes)
                {
                    Remove(node.Children, item);
                }
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var task = GetAsync();
            Task.WhenAll(task);
            var items = task.Result;
            if (items == null) return string.Empty;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(">> ").AppendLine(typeof(TEntity).Name);
            GetHeaderStrings(items.ToList(), stringBuilder, out int[] headerLengths);
            GetContentStrings(items.ToList(), headerLengths, stringBuilder);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 文字列取得
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
        private void GetStrings(List<TEntity> items, StringBuilder stringBuilder)
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
                if (item is DbTableNode<TEntity> node)
                {
                    stringBuilder.AppendLine(node.ToNodeString());
                    continue;
                }
                stringBuilder.AppendLine(item.ToContentString());
            }
        }

        /// <summary>
        /// ヘッダーの文字列取得
        /// </summary>
        private void GetHeaderStrings(List<TEntity> items, StringBuilder stringBuilder, out int[] headerLengths)
        {
            //ヘッダー情報取得
            var firstItem = items.FirstOrDefault();
            if (firstItem == null)
            {
                headerLengths = null;
                return;
            }
            var headerStrings = firstItem.GetHeaderStrings();
            headerLengths = new int[headerStrings.Length];
            for (var i = 0; i < headerStrings.Length; i++)
            {
                headerLengths[i] = headerStrings[i].Length;
            }
            //各項目の最大文字列サイズ取得
            foreach (var item in items)
            {
                var contentStrings = item.GetContentStrings();
                for (var i = 0; i < contentStrings.Length; i++)
                {
                    if (headerLengths[i] < contentStrings[i].Length)
                    {
                        headerLengths[i] = contentStrings[i].Length;
                    }
                }
            }
            headerLengths = headerLengths.Select(x => x + 2).ToArray();
            //ヘッダーを生成
            var headerLine = "";
            for (int i = 0; i < headerLengths.Length; i++)
            {
                //ヘッダー文字を最大長さに調整
                for (int j = 0; j < headerLengths[i]; j++)
                {
                    headerLine += Document.HeaderLine;
                }
                stringBuilder.Append(headerStrings[i].PadRight(headerLengths[i]));
            }
            stringBuilder.AppendLine();
            stringBuilder.Append(headerLine);
            stringBuilder.AppendLine();
        }

        /// <summary>
        /// コンテンツの文字列取得
        /// </summary>
        /// <param name="items"></param>
        /// <param name="stringBuilder"></param>
        private void GetContentStrings(List<TEntity> items, int[] headerLengths, StringBuilder stringBuilder)
        {
            foreach (var item in items)
            {
                var contentStrings = item.GetContentStrings();
                for (int i = 0; i < contentStrings.Length; i++)
                {
                    stringBuilder.Append(contentStrings[i].PadRight(headerLengths[i]));
                }
                stringBuilder.AppendLine();
            }
        }

        #endregion 内部メソッド

    }
}