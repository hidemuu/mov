using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IUserSettingRepository
    {
        IEnumerable<UserSetting> Gets();
    }
}
