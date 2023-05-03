using Mov.Configurator.Models.Schemas;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public interface IConfiguratorService
    {
        IPersistenceCommand<UserSettingSchema> Command { get; }

        IPersistenceQuery<UserSettingSchema> Query { get; }
    }
}
