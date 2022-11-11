using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.Accessors.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase
    {
        public override string DomainPath => "configurator";

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
