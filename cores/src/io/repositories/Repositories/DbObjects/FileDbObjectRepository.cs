using Mov.Core.Accessors.Services;
using Mov.Core.Models.DbObjects.Entities;
using Mov.Core.Repositories.Repositories.Entities;
using Mov.Core.Templates.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Core.Repositories.Repositories.DbObjects
{
    /// <summary>
    /// データベースリポジトリ基本クラス
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class FileDbObjectRepository<TEntity, TBody>
        : FileEntityRepository<TEntity, TBody>, IDbObjectRepository<TEntity, TBody>
        where TEntity : DbObject
        where TBody : DbObjectCollection<TEntity>
    {
        #region フィールド

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        public FileDbObjectRepository(string fileName, string encoding = CoreConstants.ENCODE_NAME_UTF8)
            : base(new FileAccessService(fileName, encoding))
        {

        }

        #region メソッド


        #region GET

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity Get(Guid id) => Get(Get(), id);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TEntity Get(int index) => Get(Get(), index);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override TEntity Get(string code) => Get(Get(), code);

        #endregion GET

        #region POST

        /// <summary>
        /// 全データ追加・更新
        /// </summary>
        /// <param name="items"></param>
        public void Posts(IEnumerable<TEntity> items)
        {
            List<TEntity> srcs = Get().ToList();
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
        public override void Post(TEntity item)
        {
            var src = Get().FirstOrDefault(x => x.Id == item.Id);
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
            var items = Get().ToList();
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
            if (item is DbObjectNode<TEntity>)
            {
                var src = Get(Get(), id);
                if (src == null) return;
                if (src is DbObjectNode<TEntity> node)
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
            var srcs = Get().ToList();
            Remove(srcs, item);
            body.Items = srcs.ToArray();
        }

        public void Delete(Guid id)
        {
            var srcs = Get().ToList();
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
            var src = Get().FirstOrDefault(x => x.Id == id);
            if (src == null) return;
            var moved = Get().FirstOrDefault(x => x.Id == movedId);
            if (moved == null) return;
            if (src is DbObjectNode<TEntity> srcNode)
            {
                if (!(moved is DbObjectNode<TEntity> movedNode)) return;
                var srcNodeClone = new DbObjectNode<TEntity>(srcNode);
                srcNode = new DbObjectNode<TEntity>(movedNode);
                movedNode = new DbObjectNode<TEntity>(srcNodeClone);
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
            var items = Get().ToArray();
            var src = items[arrayIndex];
            var moved = items[movedIndex];
            var querys = Get().ToArray();
            querys[arrayIndex] = moved;
            querys[movedIndex] = src;
            body.Items = querys;
        }

        public void MoveNext(Guid id)
        {
            var arrayIndex = GetArrayIndex(id);
            var movedIndex = arrayIndex + 1;
            if (movedIndex > body.Items.Length) return;
            var items = Get().ToArray();
            var src = items[arrayIndex];
            var moved = items[movedIndex];
            var querys = Get().ToArray();
            querys[arrayIndex] = moved;
            querys[movedIndex] = src;
            body.Items = querys;
        }

        private int GetArrayIndex(Guid id)
        {
            var items = Get().ToArray();
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
            if (!(items is IEnumerable<DbObjectNode<TEntity>> nodes)) return item;
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
            if (items is IEnumerable<DbObjectNode<TEntity>> nodes)
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
                if (item is DbObjectNode<TEntity> node)
                {
                    stringBuilder.AppendLine(node.ToNodeString());
                    continue;
                }
                stringBuilder.AppendLine(item.ToContentString());
            }
        }

        #endregion 内部メソッド
    }
}