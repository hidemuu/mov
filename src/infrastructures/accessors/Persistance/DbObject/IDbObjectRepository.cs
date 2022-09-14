using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors
{
    // <summary>
    /// データベースリポジトリインターフェース
    /// </summary>
    public interface IDbObjectRepository<T, C> where T : DbObject where C : DbObjectCollection<T>
    {
        /// <summary>
        /// インポート
        /// </summary>
        void Import();

        /// <summary>
        /// エクスポート
        /// </summary>
        void Export();

        /// <summary>
        /// 単一データエクスポート
        /// </summary>
        /// <param name="item"></param>
        void Export(T item);

        #region GET

        /// <summary>
        /// 全データ取得
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Gets();

        /// <summary>
        /// 全データ取得（非同期）
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetsAsync();

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(Guid id);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Get(int index);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        T Get(string code);

        #endregion GET

        #region POST

        /// <summary>
        /// 全データ追加・更新
        /// </summary>
        /// <param name="items"></param>
        void Posts(IEnumerable<T> items);

        /// <summary>
        /// データ追加・更新
        /// </summary>
        /// <param name="item"></param>
        void Post(T item);

        #endregion POST

        #region PUT

        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="item"></param>
        void Put(T item);

        /// <summary>
        /// データ追加（位置指定）
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        void Put(T item, Guid id);

        #endregion PUT

        #region DELETE

        /// <summary>
        /// データ削除
        /// </summary>
        /// <param name="item"></param>
        void Delete(T item);

        void Delete(Guid id);

        #endregion DELETE

        #region MOVE

        /// <summary>
        /// データ移動
        /// </summary>
        /// <param name="id">移動元ID</param>
        /// <param name="movedId">移動先ID</param>
        void Move(Guid id, Guid movedId);

        void MovePrev(Guid id);

        void MoveNext(Guid id);

        #endregion MOVE
    }
}
