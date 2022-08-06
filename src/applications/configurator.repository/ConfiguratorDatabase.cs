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
    public class ConfiguratorDatabase : DbObjectDatabaseBase<IConfiguratorRepository>, IConfiguratorDatabase
    {
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorDatabase(string resourceDir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir)
        {
            Repositories = new Dictionary<string, IConfiguratorRepository>()
            {
                { "", new ConfiguratorRepository(resourceDir, extension, encode) },
            };
        }

        #endregion コンストラクター

    }
}
