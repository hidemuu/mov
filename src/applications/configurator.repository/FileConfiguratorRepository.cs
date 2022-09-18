using Mov.Accessors;
using Mov.BaseModel;
using Mov.Configurator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class FileConfiguratorRepository : DomainRepositoryBase, IConfiguratorRepository
    {

        public FileConfiguratorRepository(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8) : base(extension)
        {
            UserSettings = new DbObjectRepository<Config, ConfigCollection>(dir, GetRelativePath("user_setting"), encode);
        }

        #region プロパティ

        public IDbObjectRepository<Config> UserSettings { get; }

        #endregion
    }
}
