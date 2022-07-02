using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepositoryCollection
    {
        DbObjectRepository<Config, ConfigCollection> Configs { get; }
        DbObjectRepository<Variable, VariableCollection> Variables { get; }
    }
}
