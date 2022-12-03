using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public class SchemaQuery : IPersistenceQuery<Schema>
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public SchemaQuery(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Schema> Gets()
        {
            return this.repository.Schemas.Get();
        }

        public IEnumerable<Schema> Gets(string param)
        {
            return Gets().Where(x => x.Name == param);
        }

        public Schema Get(Guid id)
        {
            return this.repository.Schemas.Get(id);
        }

        public Schema Get(string param)
        {
            return this.repository.Schemas.Get(param);
        }

        public override string ToString() => this.repository.Schemas.ToString();

        #endregion メソッド
    }
}
