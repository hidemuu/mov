using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Configurators
{
    public class ConfiguratorQuery : IPersistenceQuery<Config>
    {
        #region フィールド

        private readonly FileConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ConfiguratorQuery(FileConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Config> Gets()
        {
            return this.repository.Configs.Get();
        }

        public IEnumerable<Config> Gets(string param)
        {
            return Gets().Where(x => x.Name == param);
        }

        public Config Get(Guid id)
        {
            return this.repository.Configs.Get(id);
        }

        public Config Get(string param)
        {
            return this.repository.Configs.Get(param);
        }

        public override string ToString() => this.repository.Configs.ToString();

        #endregion メソッド
    }
}
