using Mov.Core.Configurators.Repositories.Schemas;
using Mov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators
{
    public interface IConfiguratorRepository : IDomainRepository
    {
        IDbObjectRepository<ConfigSchema, Guid> Configs { get; }
    }
}
