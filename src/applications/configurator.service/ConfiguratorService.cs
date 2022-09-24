using Mov.Configurator.Models;
using System;

namespace Mov.Configurator.Service
{
    /// <summary>
    /// コンフィグレーションのサービス
    /// </summary>
    public class ConfiguratorService
    {
        /// <summary>
        /// リポジトリ
        /// </summary>
        private readonly IConfiguratorRepository repository;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public ConfiguratorService(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }
    }
}
