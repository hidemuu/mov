using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.Accessors.Repository.Implement;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Schemas;
using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Repository.File
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase, IConfiguratorRepository
    {
        public override string DomainPath => "configurator";

        public FileConfiguratorRepository(string endpoint, string fileDir, string extension, string encoding = AccessConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            UserSettings = new FileDbObjectRepository<UserSettingSchema, UserSettingCollectionSchema>(GetPath("config"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<UserSettingSchema, UserSettingCollectionSchema> UserSettings { get; }

        #endregion プロパティ
    }
}
