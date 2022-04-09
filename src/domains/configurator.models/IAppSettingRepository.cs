using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IAppSettingRepository
    {
        IEnumerable<AppSetting> Gets();
    }
}
