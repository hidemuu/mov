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
        }

        #region プロパティ

        public IDbObjectRepository<UserSetting> UserSettings { get; }

        #endregion
    }
}
