using Mov.Core.Configurators.Repositories.Schemas;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Implements.Domains;
using Mov.Core.Repositories.Implements.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase, IConfiguratorRepository
    {

        #region property

        public override string DomainPath => "configurator";

        public IDbObjectRepository<ConfigSchema, ConfigSchemaCollection> Configs { get; }

        #endregion property

        #region constructor

        public FileConfiguratorRepository(string endpoint, FileType fileType, EncodingValue encoding)
            : base(endpoint, fileType, encoding)
        {
            Configs = new FileDbObjectRepository<ConfigSchema, ConfigSchemaCollection>(GetPath("config"), encoding, fileType);
        }

        #endregion constructor

    }
}
