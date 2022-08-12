using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository
    {
        IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        IDbObjectRepository<Account, AccountCollection> Accounts { get; }

        IDbObjectRepository<Translate, TranslateCollection> Translates { get; }

        IDbObjectRepository<Icon, IconCollection> Icons { get; }
    }
}
