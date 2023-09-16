using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Configurators.Models.Schemas;
using Mov.Core.Repositories;
using Mov.Core.Repositories.Services;
using System;
using System.IO;

namespace Mov.Core.Configurators.Repositories
{
    public class FileConfiguratorRepository : IConfiguratorRepository
    {
        #region property

        public IDbRepository<ConfigSchema, Guid> Configs { get; }

        #endregion property

        #region constructor

        public FileConfiguratorRepository(string endpoint, FileType fileType, EncodingValue encoding)
        {
            var client = new FileClient(new PathValue(Path.Combine(endpoint, "configurator")), encoding, AccessType.Create(fileType));
            Configs = new FileDbRepository<ConfigSchema, Guid>(client);
        }

        #endregion constructor
    }
}