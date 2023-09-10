using Mov.Core.Accessors;
using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.DbObjects;
using System;
using System.IO;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepository : IConfiguratorRepository
    {
        #region property

        public IDbObjectRepository<ConfigSchema, Guid> Configs { get; }

        #endregion property

        #region constructor

        public FileConfiguratorRepository(string endpoint, FileType fileType, EncodingValue encoding)
        {
            var client = new FileClient(new PathValue(Path.Combine(endpoint, "configurator")), encoding, AccessType.Create(fileType));
            Configs = new FileDbObjectRepository<ConfigSchema, Guid>(client);
        }

        #endregion constructor
    }
}