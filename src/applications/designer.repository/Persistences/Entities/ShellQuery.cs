using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class ShellQuery : IPersistenceQuery<Shell>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ShellQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Shell> Gets()
        {
            return this.repository.Shells.Get();
        }

        public IEnumerable<Shell> Gets(string param)
        {
            return Gets().Where(x => x.Code == param);
        }

        public Shell Get(Guid id)
        {
            return this.repository.Shells.Get(id);
        }

        public Shell Get(string param)
        {
            return this.repository.Shells.Get(param);
        }

        public override string ToString() => this.repository.Shells.ToString();

        #endregion メソッド
    }
}
