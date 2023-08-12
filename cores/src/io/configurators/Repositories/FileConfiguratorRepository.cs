using Mov.Core.Configurators.Repositories.Schemas;
using Mov.Core.Models.Texts;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Implements.Domains;
using Mov.Core.Repositories.Implements.DbTables;
using System;
using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Models.Connections;
using System.IO;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepository : FileDomainRepositoryBase, IConfiguratorRepository
    {

        #region property

        public override string DomainPath => "configurator";

        public IDbObjectRepository<ConfigSchema, Guid> Configs { get; }

        #endregion property

        #region constructor

        public FileConfiguratorRepository(string endpoint, FileType fileType, EncodingValue encoding)
            : base(endpoint, fileType, encoding)
        {
            var serializer = new SerializerFactory(new PathValue(GetPath("config")), encoding).Create(AccessType.Create(fileType));
            Configs = new FileDbObjectRepository<ConfigSchema, Guid>(serializer);
        }

        #endregion constructor

    }
}
