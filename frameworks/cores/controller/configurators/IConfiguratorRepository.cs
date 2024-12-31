using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Schemas.Requests;
using System;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorRepository
    {
        IDbRepository<ApiSettingSchema, string, DbRequestSchemaString> ApiSettings { get; }
        IDbRepository<UserSettingSchema, Guid, DbRequestSchemaString> UserSettings { get; }
    }
}
