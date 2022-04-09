using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class UserSettingRepository : FileAccessor<UserSetting>, IUserSettingRepository
    {
        public readonly static string FILE_NAME = "user_setting";
        public UserSettingRepository(IFileHelper fileHelper) : base(fileHelper)
        {
        }
    }
}
