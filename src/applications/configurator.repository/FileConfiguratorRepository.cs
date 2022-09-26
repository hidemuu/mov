using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.Accessors.Repository.Implement;
using Mov.BaseModel;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase, IConfiguratorRepository
    {
        public override string DomainPath => "configurator";

        public FileConfiguratorRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            UserSettings = new FileDbObjectRepository<UserSetting, UserSettingCollection>(GetPath("user_setting"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        #endregion
    }
}
