using Mov.Configurator.Models;
using Mov.Configurator.Models.Parameters;
using Mov.Configurator.Models.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Repository
{
    public class ConfiguratorParameter : IConfiguratorParameter
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region プロパティ

        public IConfiguratorCommand Command { get; }

        public IConfiguratorQuery Query { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConfiguratorParameter(IConfiguratorRepository repository)
        {
            this.repository = repository;
            this.Query = new ConfiguratorQuery(repository);
            this.Command = new ConfiguratorCommand(repository);
        }

        #endregion コンストラクター

    }
}
