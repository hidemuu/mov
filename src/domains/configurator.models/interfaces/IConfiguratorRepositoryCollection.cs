using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepositoryCollection
    {
        DbObjectRepositoryBase<Config, ConfigCollection> Configs { get; }
        DbObjectRepositoryBase<Variable, VariableCollection> Variables { get; }
    }
}
