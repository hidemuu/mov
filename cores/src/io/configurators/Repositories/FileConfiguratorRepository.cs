using Mov.Core.Configurators.Repositories.Schemas;
using Mov.Core.Repositories.Repositories.DbObjects;
using Mov.Core.Repositories.Repositories.Domains;
using Mov.Core.Templates.Repositories;
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

        public FileConfiguratorRepository(string endpoint, string fileDir, string extension, string encoding = CoreConstants.ENCODE_NAME_UTF8)
            : base(endpoint, fileDir, extension, encoding)
        {
            Configs = new FileDbObjectRepository<ConfigSchema, ConfigSchemaCollection>(GetPath("config"), encoding);
        }

        #endregion constructor

    }
}
