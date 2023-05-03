using Mov.Configurator.Models;
using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Engine.Persistences
{
    public class ConfiguratorPersistenceQuery : IConfiguratorQuery
    {
        public IPersistenceQuery<UserSettingSchema> UserSetting { get; }

        public IPersistenceQuery<SystemSettingSchema> SystemSetting { get; }

        public IPersistenceQuery<LanguageSchema> Language { get; }
    }
}
