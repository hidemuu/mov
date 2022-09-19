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
        public override string RelativePath => "configurator";

        public FileConfiguratorRepository(string dir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8)
            : base(dir, extension, encoding)
        {
            Configs = new FileDbObjectRepository<Config, ConfigCollection>(dir, GetRelativePath("config"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<Config, ConfigCollection> Configs { get; }

        #endregion
    }
}
