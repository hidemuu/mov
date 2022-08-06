using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorRepository : DbObjectRepositoryBase, IConfiguratorRepository
    {

        public ConfiguratorRepository(string resourceDir, string extension, string encode = DbConstants.ENCODE_NAME_UTF8) : base(resourceDir, extension)
        {
            UserSettings = new DbObjectRepository<UserSetting, UserSettingCollection>(this.dir, GetRelativePath("config"), encode);
            Accounts = new DbObjectRepository<Account, AccountCollection>(this.dir, GetRelativePath("account"), encode);
            Translates = new DbObjectRepository<Translate, TranslateCollection>(this.dir, GetRelativePath("translate"), encode);
            Icons = new DbObjectRepository<Icon, IconCollection>(this.dir, GetRelativePath("icon"), encode);
        }

        #region プロパティ

        public IRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        public IRepository<Account, AccountCollection> Accounts { get; }

        public IRepository<Translate, TranslateCollection> Translates { get; }

        public IRepository<Icon, IconCollection> Icons { get; }

        #endregion
    }
}
