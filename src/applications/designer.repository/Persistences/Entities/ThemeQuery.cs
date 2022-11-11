using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class ThemeQuery : IPersistenceQuery<Theme>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ThemeQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Theme> Get()
        {
            return this.repository.Themes.Get();
        }

        public IEnumerable<Theme> Get(string param)
        {
            return Get().Where(x => x.Code == param);
        }

        public Theme Get(Guid id)
        {
            return this.repository.Themes.Get(id);
        }

        public override string ToString() => this.repository.Themes.ToString();

        #endregion メソッド
    }
}
