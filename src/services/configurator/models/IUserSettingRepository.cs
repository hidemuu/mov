using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Models
{
    public interface IUserSettingRepository
    {
        IEnumerable<UserSetting> Gets();
    }
}
