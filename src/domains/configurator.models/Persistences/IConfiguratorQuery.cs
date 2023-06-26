using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public interface IConfiguratorQuery
    {
        IPersistenceQuery<Error> Error { get; }

        IPersistenceQuery<Schema> Schema { get; }

        IPersistenceQuery<UserSetting> UserSetting { get; }
    }
}
