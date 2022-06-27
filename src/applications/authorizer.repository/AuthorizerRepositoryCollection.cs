using Mov.Authorizer.Repository;
using Mov.Authorizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mov.Accessors;
using Mov.Accessors.Repository;

namespace Mov.Authorizer.Repository
{
    /// <summary>
    /// オーソライズのリポジトリ
    /// </summary>
    public class AuthorizerRepositoryCollection : DbObjectRepositoryCollectionBase, IAuthorizerRepositoryCollection
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public AuthorizerRepositoryCollection(string resourceDir, string extension, string encoding = "utf-8") : base(resourceDir, extension)
        {
            Users = new UserRepository(GetRepositoryPath("user"), encoding);
        }

        #region プロパティ

        public DbObjectRepositoryBase<User, UserCollection> Users { get; }

        #endregion
    }
}
