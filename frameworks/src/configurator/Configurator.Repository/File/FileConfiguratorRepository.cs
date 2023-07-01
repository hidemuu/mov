using Mov.Configurator.Models;
using Mov.Core;
using Mov.Core.Repositories.Repositories.DbObjects;
using Mov.Core.Repositories.Repositories.Domains;
using Mov.Core.Templates.Repositories;

namespace Configurator.Repository.File
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase, IConfiguratorRepository
    {
        public override string DomainPath => "configurator";

        public FileConfiguratorRepository(string endpoint, string fileDir, string extension, string encoding = CoreConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            UserSettings = new FileDbObjectRepository<UserSetting, UserSettingCollection>(GetPath("config"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        #endregion プロパティ
    }
}