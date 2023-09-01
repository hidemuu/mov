using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories.Services.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorRepository
    {
        IDbObjectRepository<ConfigSchema, Guid> Configs { get; }
    }
}
