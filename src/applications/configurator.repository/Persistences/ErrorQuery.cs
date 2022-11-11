using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public class ErrorQuery : IPersistenceQuery<Error>
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ErrorQuery(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド
        
        public IEnumerable<Error> Get()
        {
            return this.repository.Errors.Get();
        }

        public IEnumerable<Error> Get(string param)
        {
            return Get().Where(x =>x.Name == param);
        }

        public Error Get(Guid id)
        {
            return this.repository.Errors.Get(id);
        }

        public override string ToString() => this.repository.Errors.ToString();

        #endregion メソッド

    }
}
