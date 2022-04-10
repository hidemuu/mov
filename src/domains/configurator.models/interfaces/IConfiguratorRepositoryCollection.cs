using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepositoryCollection
    {
        FileRepositoryBase<UserSetting, UserSettingCollection> UserSettings { get; }
        FileRepositoryBase<AppSetting, AppSettingCollection> AppSettings { get; }
        FileRepositoryBase<Variable, VariableCollection> Variables { get; }
    }
}
