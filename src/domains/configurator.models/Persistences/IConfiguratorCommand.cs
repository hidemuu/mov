using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorCommand
    {
        IPersistenceCommand<Error> Error { get; }

        IPersistenceCommand<Schema> Schema { get; }

        IPersistenceCommand<UserSetting> UserSetting { get; }
    }
}
