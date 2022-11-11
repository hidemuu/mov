using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.Accessors.Repository.Implement;
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
            Errors = new FileDbObjectRepository<Error, ErrorCollection>(GetPath("error"), encoding);
            Schemas = new FileDbObjectRepository<Schema, SchemaCollection>(GetPath("schema"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<UserSetting, UserSettingCollection> UserSettings { get; }

        public IDbObjectRepository<Error, ErrorCollection> Errors { get; }

        public IDbObjectRepository<Schema, SchemaCollection> Schemas { get; }

        #endregion
    }
}
