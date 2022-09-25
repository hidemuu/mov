using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Commands;
using Mov.Controllers;
using Mov.Controllers.Service;
using Mov.Utilities;
using System;
using System.Collections.Generic;

namespace Mov.Configurator.Service
{
    /// <summary>
    /// コンフィグレーションのサービス
    /// </summary>
    public class ConfiguratorService : DomainService<IConfiguratorRepository>
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorService(IConfiguratorRepository repository) : base(repository, new ConfiguratorCommandFactory())
        {
        }
    }
}
