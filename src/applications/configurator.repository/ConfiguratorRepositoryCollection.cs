using Mov.Accessors;
using Mov.Accessors.Repository;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Mov.Configurator.Repository
{
    /// <summary>
    /// コンフィグレーションデータのリポジトリ
    /// </summary>
    public class ConfiguratorRepositoryCollection : DbObjectRepositoryCollectionBase, IConfiguratorRepositoryCollection
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorRepositoryCollection(string resourceDir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Configs = new DbObjectRepository<Config, ConfigCollection>(GetRepositoryPath("config"), encode);
            Accounts = new DbObjectRepository<Account, AccountCollection>(GetRepositoryPath("account"), encode);
            Translates = new DbObjectRepository<Translate, TranslateCollection>(GetRepositoryPath("translate"), encode);
        }

        #endregion コンストラクター

        #region プロパティ

        /// <summary>
        /// 設定のリポジトリ
        /// </summary>
        public DbObjectRepository<Config, ConfigCollection> Configs { get; }

        public DbObjectRepository<Account, AccountCollection> Accounts { get; }

        public DbObjectRepository<Translate, TranslateCollection> Translates { get; }

        #endregion プロパティ

    }
}
