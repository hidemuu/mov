using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorDatabase
    {
        IRepository<Config, ConfigCollection> Configs { get; }

        IRepository<Account, AccountCollection> Accounts { get; }

        IRepository<Translate, TranslateCollection> Translates { get; }

    }
}
