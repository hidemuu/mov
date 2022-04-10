using Mov.Accessors;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class UserSettingRepository : FileRepositoryBase<UserSetting, UserSettingCollection>, IUserSettingRepository
    {
        public UserSettingRepository(string path, string encoding = "utf-8") : base(path, encoding)
        {
        }
    }
}
