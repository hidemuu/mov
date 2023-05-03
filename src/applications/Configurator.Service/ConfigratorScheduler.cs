using Configurator.Engine;
using Mov.Configurators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configurator.Service
{
    public class ConfigratorScheduler : IConfiguratorScheduler
    {
        #region フィールド

        private readonly IConfiguratorService _service;

        #endregion フィールド

        #region コンストラクター

        public ConfigratorScheduler(IConfiguratorService service) 
        {
            _service = service;
        }

        #endregion コンストラクター
    }
}
