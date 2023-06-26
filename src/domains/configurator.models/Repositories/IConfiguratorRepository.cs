using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository : IDomainRepository
    {
        IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        IDbObjectRepository<Error, ErrorCollection> Errors { get; }

        IDbObjectRepository<Schema, SchemaCollection> Schemas { get; }
    }
}
