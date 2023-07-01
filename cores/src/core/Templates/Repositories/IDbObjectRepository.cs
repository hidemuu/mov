using Mov.Core.Models.Entities.DbObjects;
using System;
using System.Collections.Generic;

namespace Mov.Core.Templates.Repositories
{
    // <summary>
    /// データベースリポジトリインターフェース
    /// </summary>
    public interface IDbObjectRepository<TEntity, TBody>
        : IEntityRepositoryAsync<TEntity>, IEntityRepository<TEntity>, IFileRepository<TBody>
        where TEntity : DbObject
    {
        #region GET

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(Guid id);

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        TEntity Get(int index);

        #endregion GET

        #region POST

        /// <summary>
        /// 全データ追加・更新
        /// </summary>
        /// <param name="items"></param>
        void Posts(IEnumerable<TEntity> items);

        #endregion POST

        #region PUT

        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="item"></param>
        void Put(TEntity item);

        /// <summary>
        /// データ追加（位置指定）
        /// </summary>
        /// <param name="item"></param>
        /// <param name="id"></param>
        void Put(TEntity item, Guid id);

        #endregion PUT

        #region DELETE

        /// <summary>
        /// データ削除
        /// </summary>
        /// <param name="item"></param>
        void Delete(TEntity item);

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