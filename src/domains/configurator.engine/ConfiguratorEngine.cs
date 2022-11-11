using Mov.Configurator.Models;
using System;

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
            return this.service.Repository.Errors.Get(param);
        }

        public Schema GetSchema(string param)
        {
            return this.service.Repository.Schemas.Get(param);
        }

        public UserSetting GetUserSetting(string param)
        {
            return this.service.Repository.UserSettings.Get(param);
        }


        #endregion メソッド

    }
}
