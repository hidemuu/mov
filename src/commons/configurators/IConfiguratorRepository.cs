using Mov.Accessors;
using Mov.Configurator.Models.Schemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository
    {
        IDbObjectRepository<UserSettingSchema, UserSettingCollectionSchema> UserSettings { get; }
    }
}
