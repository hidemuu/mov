using Mov.Accessors.Repository.Domain;
using Mov.BaseModel;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Commands;
using Mov.Controllers;
using Mov.Utilities;
using System;
using System.Collections.Generic;

namespace Mov.Configurator.Service
{
    /// <summary>
    /// コンフィグレーションのサービス
    /// </summary>
    public class ConfiguratorService : IConfiguratorService
    {
        public IConfiguratorRepository Repository { get; }

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this.Repository = repository;
        }
    }
}
