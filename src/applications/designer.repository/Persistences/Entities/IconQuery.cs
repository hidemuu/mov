using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class IconQuery : IPersistenceQuery<Icon>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public IconQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Icon> Get()
        {
            return default;
        }

        public IEnumerable<Icon> Get(string param)
        {
            return Get().Where(x => x.Name == param);
        }

        public Icon Get(Guid id)
        {
            return default;
        }

        //public override string ToString() => this.repository.Icons.ToString();

        #endregion メソッド
    }
}
