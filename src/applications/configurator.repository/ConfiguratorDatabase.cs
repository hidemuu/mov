using Mov.Accessors;
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
    public class ConfiguratorDatabase : DbObjectDatabaseBase, IConfiguratorDatabase
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorDatabase(string resourceDir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            Configs = new DbObjectRepository<Config, ConfigCollection>(this.dir, GetRelativePath("config"), encode);
            Accounts = new DbObjectRepository<Account, AccountCollection>(this.dir, GetRelativePath("account"), encode);
            Translates = new DbObjectRepository<Translate, TranslateCollection>(this.dir, GetRelativePath("translate"), encode);
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
