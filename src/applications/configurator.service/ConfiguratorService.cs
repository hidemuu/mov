using Mov.Accessors;
using Mov.Accessors.Repository.Domain;
using Mov.Configurator.Models;
using Mov.Configurator.Models.Persistences;
using Mov.Configurator.Repository;
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
        #region フィールド

        private readonly IConfiguratorEngine engine;

        #endregion フィールド

        #region プロパティ

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorService(IConfiguratorEngine engine)
        {
            this.engine = engine;
        }

        #endregion コンストラクター

        #region メソッド

        public override string ToString()
        {
            return engine.ToString();
        }

        #endregion メソッド
    }
}
