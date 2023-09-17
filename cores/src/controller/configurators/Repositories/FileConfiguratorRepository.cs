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
            Configs = FileDbRepository<ConfigSchema, Guid>.Factory.Create(Path.Combine(endpoint, "config.json"), fileType, encoding);
        }

        #endregion constructor
    }
}