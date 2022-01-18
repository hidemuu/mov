using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class AppSettingRepository : FileAccessor<AppSetting>, IAppSettingRepository
    {
        public readonly static string FILE_NAME = "app_setting";
        public AppSettingRepository(IFileHelper fileHelper) : base(fileHelper)
        {
        }
    }
}
