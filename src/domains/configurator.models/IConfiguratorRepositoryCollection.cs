using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepositoryCollection
    {
        IUserSettingRepository UserSettings { get; }
        IAppSettingRepository AppSettings { get; }
        IVariableRepository Variables { get; }
    }
}
