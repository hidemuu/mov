using Mov.Configurator.Engine;

namespace Mov.Configurator.Service
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