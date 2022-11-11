using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public class SchemaCommand : IPersistenceCommand<Schema>
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public SchemaCommand(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(Schema item)
        {
            this.repository.Schemas.Delete(item);
        }

        public void Post(Schema item)
        {
            this.repository.Schemas.Post(item);
        }

        #endregion メソッド
    }
}
