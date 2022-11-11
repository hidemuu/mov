using Mov.Configurator.Models;
using System;
using System.Linq;

namespace Mov.Configurator.Engine
{
    public class ConfiguratorEngine : IConfiguratorEngine
    {
        #region フィールド

        private readonly IConfiguratorService service;

        #endregion フィールド

        #region コンストラクター

        public ConfiguratorEngine(IConfiguratorService service)
        {
            this.service = service;
        }

        #endregion コンストラクター

        #region メソッド

        public Error GetError(string param)
        {
            return this.service.Query.Error.Get(param).FirstOrDefault();
        }

        public Schema GetSchema(string param)
        {
            return this.service.Query.Schema.Get(param).FirstOrDefault();
        }

        public UserSetting GetUserSetting(string param)
        {
            return this.service.Query.UserSetting.Get(param).FirstOrDefault();
        }


        #endregion メソッド

    }
}
