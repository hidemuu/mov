using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Domain
{
    public interface IDomainRepositoryCollection<TRepository>
    {
        #region プロパティ

        /// <summary>
        /// リポジトリのリスト
        /// </summary>
        IDictionary<string, TRepository> Repositories { get; }

        /// <summary>
        /// 既定のリポジトリ名
        /// </summary>
        /// <returns></returns>
        string DefaultRepositoryName { get; }

        #endregion プロパティ

        #region メソッド

        /// <summary>
        /// 既定のリポジトリ
        /// </summary>
        TRepository GetDefaultRepository();


        /// <summary>
        /// リポジトリ名のリストを取得
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetRepositoryNames();

        /// <summary>
        /// 指定のリポジトリを取得
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        TRepository GetRepository(string dirName);

        #endregion メソッド
    }
}
