using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorRepository : DbObjectRepositoryBase, IConfiguratorRepository
    {

        public ConfiguratorRepository(string dir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            UserSettings = new DbObjectRepository<UserSetting, UserSettingCollection>(dir, GetRelativePath("user_setting"), encode);
            Accounts = new DbObjectRepository<Account, AccountCollection>(dir, GetRelativePath("account"), encode);
            Translates = new DbObjectRepository<Translate, TranslateCollection>(dir, GetRelativePath("translate"), encode);
            Icons = new DbObjectRepository<Icon, IconCollection>(dir, GetRelativePath("icon"), encode);
        }

        #region プロパティ

        public IRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        public IRepository<Account, AccountCollection> Accounts { get; }

        public IRepository<Translate, TranslateCollection> Translates { get; }

        public IRepository<Icon, IconCollection> Icons { get; }

        #endregion
    }
}
