using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class RepositoryThemeQuery : IPersistenceQuery<Theme>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public RepositoryThemeQuery(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<Theme> Read()
        {
            return this.repository.Themes.Read().Items;
        }

        public IEnumerable<Theme> Gets()
        {
            return this.repository.Themes.Get();
        }

        public IEnumerable<Theme> Gets(string param)
        {
            return Gets().Where(x => x.Code == param);
        }

        public Theme Get(Guid id)
        {
            return this.repository.Themes.Get(id);
        }

        public Theme Get(string param)
        {
            return this.repository.Themes.Get(param);
        }

        public override string ToString() => this.repository.Themes.ToString();

        #endregion メソッド
    }
}
