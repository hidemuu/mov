using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepositoryCollection
    {
        DbObjectRepositoryBase<UserSetting, UserSettingCollection> UserSettings { get; }
        DbObjectRepositoryBase<Variable, VariableCollection> Variables { get; }
    }
}
