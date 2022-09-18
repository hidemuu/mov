using Mov.Accessors;
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

        public FileConfiguratorRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(dir, extension, encode)
        {
            UserSettings = new FileDbObjectRepository<Config, ConfigCollection>(dir, GetRelativePath("user_setting"), encode);
        }

        #region プロパティ

        public IDbObjectRepository<Config, ConfigCollection> UserSettings { get; }

        #endregion
    }
}
