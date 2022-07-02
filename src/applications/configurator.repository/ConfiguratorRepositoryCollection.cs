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
            Configs = new ConfigRepository(GetRepositoryPath("config"), encode);
            Variables = new VariableRepository(GetRepositoryPath("variable"), encode);
        }

        #endregion コンストラクター

        #region プロパティ

        /// <summary>
        /// ユーザー設定のリポジトリ
        /// </summary>
        public DbObjectRepository<Config, ConfigCollection> Configs { get; }
        /// <summary>
        /// 値設定のリポジトリ
        /// </summary>
        public DbObjectRepository<Variable, VariableCollection> Variables { get; }

        #endregion プロパティ

    }
}
