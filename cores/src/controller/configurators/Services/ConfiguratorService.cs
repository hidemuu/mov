using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Configurators.Services
{
    public class ConfiguratorService : IConfiguratorService
    {
        #region field

        private readonly IConfiguratorRepository repository;

        #endregion field

        #region constructor

        public ConfiguratorService(IConfiguratorRepository repository) 
        {
            this.repository = repository;
        }

        #endregion constructor

    }
}
