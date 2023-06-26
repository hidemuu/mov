using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorEngine
    {
        Error GetError(string param);

        Schema GetSchema(string param);

        UserSetting GetUserSetting(string param);
    }
}
