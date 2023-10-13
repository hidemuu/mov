using Mov.Core.Accessors.Models;
using Mov.Core.Configurators.Repositories;
using Mov.Core.Configurators.Services;
using Mov.Core.Configurators.Stores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Contexts
{
    public class ConfiguratorContext : IConfiguratorContext
    {
        #region field

        private readonly IConfiguratorService _service;

        #endregion field

        #region constructor

        private ConfiguratorContext(string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                this._service = new ConfiguratorService(new ConfiguratorStore(new FileConfiguratorRepository(PathValue.Factory.CreateResourceRootPath().Value, FileType.Json, EncodingValue.UTF8)));
            }
            else
            {
                this._service = new ConfiguratorService(new ConfiguratorStore(new FileConfiguratorRepository(endpoint, FileType.Json, EncodingValue.UTF8)));
            }
        }

        private static ConfiguratorContext instance = new ConfiguratorContext(string.Empty);

        public static ConfiguratorContext Current => instance;

        #endregion constructor

        #region method

        public static void Initialize(string endpoint)
        {
            instance = new ConfiguratorContext(endpoint);
        }

        public void Dispose()
        {
            this._service.Dispose();
        }

        #endregion method
    }
}
