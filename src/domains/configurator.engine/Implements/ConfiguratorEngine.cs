using Mov.Configurator.Models;
using Mov.Configurator.Models.Parameters;
using System;
using System.Linq;

namespace Mov.Configurator.Engine
{
    public class ConfiguratorEngine : IConfiguratorEngine
    {
        #region フィールド

        private readonly IConfiguratorParameter parameter;

        #endregion フィールド

        #region コンストラクター

        public ConfiguratorEngine(IConfiguratorParameter parameter)
        {
            this.parameter = parameter;
        }

        #endregion コンストラクター

        #region メソッド

        public Error GetError(string param)
        {
            return this.parameter.Query.Error.Get(param).FirstOrDefault();
        }

        public Schema GetSchema(string param)
        {
            return this.parameter.Query.Schema.Get(param).FirstOrDefault();
        }

        public UserSetting GetUserSetting(string param)
        {
            return this.parameter.Query.UserSetting.Get(param).FirstOrDefault();
        }

        public override string ToString()
        {
            return
                this.parameter.Query.Error.ToString() + Utilities.UtilityConstants.NewLine +
                this.parameter.Query.Schema.ToString() + Utilities.UtilityConstants.NewLine +
                this.parameter.Query.UserSetting.ToString() + Utilities.UtilityConstants.NewLine;
        }

        #endregion メソッド

    }
}
