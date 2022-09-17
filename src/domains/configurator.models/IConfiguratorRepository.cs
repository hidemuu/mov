using Mov.Accessors;
using Mov.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository
    {
        IDbObjectRepository<UserSetting> UserSettings { get; }

        IDbObjectRepository<Account> Accounts { get; }

        IDbObjectRepository<Translate> Translates { get; }

        IDbObjectRepository<Icon> Icons { get; }
    }
}
