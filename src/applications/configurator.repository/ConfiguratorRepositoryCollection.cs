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
    public class ConfiguratorRepositoryCollection : FileRepositoryCollectionBase, IConfiguratorRepositoryCollection
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorRepositoryCollection(string resourceDir, string extension, string encode = "utf-8") : base(resourceDir, extension)
        {
            UserSettings = new UserSettingRepository(GetRepositoryPath("user_setting"), encode);
            AppSettings = new AppSettingRepository(GetRepositoryPath("app_setting"), encode);
            Variables = new VariableRepository(GetRepositoryPath("variable"), encode);
        }

        #region プロパティ

        /// <summary>
        /// ユーザー設定のリポジトリ
        /// </summary>
        public IUserSettingRepository UserSettings { get; }
        /// <summary>
        /// アプリケーション設定のリポジトリ
        /// </summary>
        public IAppSettingRepository AppSettings { get; }
        /// <summary>
        /// 値設定のリポジトリ
        /// </summary>
        public IVariableRepository Variables { get; }

        #endregion

    }
}
