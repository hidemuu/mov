using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;
using System;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorRepository
    {
        IDbRepository<ConfigSchema, Guid> Configs { get; }
    }
}
