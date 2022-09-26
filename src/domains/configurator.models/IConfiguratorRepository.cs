using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models
{
    public interface IConfiguratorRepository : IDomainRepository
    {
        IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }
    }
}
