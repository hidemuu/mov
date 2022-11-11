using Mov.Accessors;
using Mov.Designer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Designer.Repository.Persistences.Entities
{
    public class IconCommand : IPersistenceCommand<Icon>
    {
        #region フィールド

        private readonly IDesignerRepository repository;

        #endregion フィールド

        #region コンストラクター

        public IconCommand(IDesignerRepository repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(Icon item)
        {
            //this.repository.Icons.Delete(item);
        }

        public void Post(Icon item)
        {
            //this.repository.Icons.Post(item);
        }

        #endregion メソッド
    }
}
