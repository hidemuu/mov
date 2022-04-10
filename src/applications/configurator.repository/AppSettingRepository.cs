using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class AppSettingRepository : FileRepositoryBase<AppSetting, AppSettingCollection>, IAppSettingRepository
    {
        public AppSettingRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }
    }
}
