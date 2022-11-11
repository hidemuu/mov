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

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region プロパティ

        public IConfiguratorQuery Query { get; }

        public IConfiguratorCommand Command { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this.repository = repository;
            this.Query = new ConfiguratorQuery(repository);
            this.Command = new ConfiguratorCommand(repository);
        }

        #endregion コンストラクター

        #region メソッド

        #endregion メソッド
    }
}
