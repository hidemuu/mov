using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class ThemeCommand : IPersistenceCommand<Theme>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public ThemeCommand(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(Theme item)
        {
            this.repository.Themes.Delete(item);
        }

        public void Post(Theme item)
        {
            this.repository.Themes.Post(item);
        }

        #endregion メソッド
    }
}
