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
        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorRepositoryCollection(string resourceDir, string extension, string encode = "utf-8") : base(resourceDir, extension)
        {
            UserSettings = new UserSettingRepository(GetRepositoryPath("user_setting"), encode);
            AppSettings = new AppSettingRepository(GetRepositoryPath("app_setting"), encode);
            Variables = new VariableRepository(GetRepositoryPath("variable"), encode);
        }

        #endregion コンストラクター

        #region プロパティ

        /// <summary>
        /// ユーザー設定のリポジトリ
        /// </summary>
        public FileRepositoryBase<UserSetting, UserSettingCollection> UserSettings { get; }
        /// <summary>
        /// アプリケーション設定のリポジトリ
        /// </summary>
        public FileRepositoryBase<AppSetting, AppSettingCollection> AppSettings { get; }
        /// <summary>
        /// 値設定のリポジトリ
        /// </summary>
        public FileRepositoryBase<Variable, VariableCollection> Variables { get; }

        #endregion プロパティ

    }
}
