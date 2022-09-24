using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Repository
{
    public interface IDomainRepositoryCollection<TRepository>
    {
        /// <summary>
        /// リポジトリのリスト
        /// </summary>
        IDictionary<string, TRepository> Repositories { get; }

        /// <summary>
        /// 既定のリポジトリ
        /// </summary>
        TRepository DefaultRepository { get; }

        /// <summary>
        /// 指定のリポジトリを取得
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        TRepository GetRepository(string dirName);
    }
}
