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

        public void Write()
        {
            this.repository.Themes.Write();
        }

        public void Delete(Theme item)
        {
            this.repository.Themes.Delete(item);
        }
        public void Posts(IEnumerable<Theme> items)
        {
            this.repository.Themes.Posts(items);
        }
        public void Post(Theme item)
        {
            this.repository.Themes.Post(item);
        }
        public void Put(Theme item)
        {
            this.repository.Themes.Put(item);
        }

        #endregion メソッド
    }
}
