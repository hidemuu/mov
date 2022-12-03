using Mov.Accessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurator.Models.Persistences
{
    public class ErrorCommand : IPersistenceCommand<Error>
    {
        #region フィールド

        private readonly IConfiguratorRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ErrorCommand(IConfiguratorRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            this.repository.Errors.Write();
        }

        public void Delete(Error item)
        {
            this.repository.Errors.Delete(item);
        }

        public void Post(Error item)
        {
            this.repository.Errors.Post(item);
        }

        #endregion メソッド
    }
}
