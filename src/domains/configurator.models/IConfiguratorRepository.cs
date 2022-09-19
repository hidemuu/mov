using Mov.Accessors;
using Mov.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository
    {
        IDbObjectRepository<Config, ConfigCollection> Configs { get; }
    }
}
