using Mov.Configurator.Models;
using Mov.Repositories.Services;
using Mov.Repositories.Services.Repositories.DbObjects;
using Mov.Repositories.Services.Repositories.Domains;
using Mov.Utilities;

namespace Configurator.Repository.File
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase, IConfiguratorRepository
    {
        public override string DomainPath => "configurator";

        public FileConfiguratorRepository(string endpoint, string fileDir, string extension, string encoding = UtilityConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            UserSettings = new FileDbObjectRepository<UserSetting, UserSettingCollection>(GetPath("config"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        #endregion プロパティ
    }
}