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

        public FileConfiguratorRepository(string endpoint, string fileDir, string extension, string encoding = SerializeConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            Configs = new FileDbObjectRepository<Config, ConfigCollection>(GetPath("config"), encoding);
        }

        #region プロパティ

        public IDbObjectRepository<Config, ConfigCollection> Configs { get; }

        #endregion
    }
}
