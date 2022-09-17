using Mov.Accessors;
using Mov.Configurator.Models;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorRepository : DomainRepositoryBase, IConfiguratorRepository
    {

        public ConfiguratorRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            UserSettings = new DbObjectRepository<UserSetting, UserSettingCollection>(dir, GetRelativePath("user_setting"), encode);
            Accounts = new DbObjectRepository<Account, AccountCollection>(dir, GetRelativePath("account"), encode);
            Translates = new DbObjectRepository<Translate, TranslateCollection>(dir, GetRelativePath("translate"), encode);
            Icons = new DbObjectRepository<Icon, IconCollection>(dir, GetRelativePath("icon"), encode);
        }

        #region プロパティ

        public IDbObjectRepository<UserSetting> UserSettings { get; }

        public IDbObjectRepository<Account> Accounts { get; }

        public IDbObjectRepository<Translate> Translates { get; }

        public IDbObjectRepository<Icon> Icons { get; }

        #endregion
    }
}
