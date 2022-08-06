using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorDatabase
    {
        IRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        IRepository<Account, AccountCollection> Accounts { get; }

        IRepository<Translate, TranslateCollection> Translates { get; }

        IRepository<Icon, IconCollection> Icons { get; }

    }
}
