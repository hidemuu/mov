﻿using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public class ConfiguratorCommand : IPersistenceCommand<Config>
    {
        #region フィールド

        private readonly FileConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ConfiguratorCommand(FileConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            this.repository.Configs.Write();
        }

        public void Delete(Config item)
        {
            this.repository.Configs.Delete(item);
        }

        public void Posts(IEnumerable<Config> items)
        {
            this.repository.Configs.Posts(items);
        }

        public void Post(Config item)
        {
            this.repository.Configs.Post(item);
        }
        public void Put(Config item)
        {
            this.repository.Configs.Put(item);
        }

        #endregion メソッド
    }
}