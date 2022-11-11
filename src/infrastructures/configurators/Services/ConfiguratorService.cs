using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public class ConfiguratorService
    {
        private readonly ConfiguratorCommand command;

        private readonly ConfiguratorQuery query;

        public ConfiguratorService(ConfiguratorCommand command, ConfiguratorQuery query)
        {
            this.command = command;
            this.query = query;
        }

        public Config Get(string param)
        {
            return this.query.Get(param);
        }

        public override string ToString()
        {
            return this.query.ToString();
        }
    }
}
